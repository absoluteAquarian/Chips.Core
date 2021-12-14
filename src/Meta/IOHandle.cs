using Chips.Core.Specifications;
using Chips.Core.Types;
using Chips.Core.Types.UserDefined;
using Chips.Core.Utility;
using System.Numerics;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Chips.Core.Meta{
	internal class IOHandle{
		private static class ReflectionGetters{
			public static readonly ReflectionHelper<Random>.MethodPackage Random_SeedArray = new("SeedArray");
			public static readonly ReflectionHelper<Random>.MethodPackage Random_inext     = new("inext");
			public static readonly ReflectionHelper<Random>.MethodPackage Random_inextp    = new("inextp");
		}

		public const int SETTING_BINARY = 0;
		public const int SETTING_WRITENEWLINES = 1;
		public const int SETTING_WRITETOFILE = 2;
		public const int SETTING_FILE = 3;
		public const int SETTING_MODE = 4;

		internal FileMode? mode;
		internal string? file;
		internal object? handle;

		private byte settings;

		/// <summary>
		/// Whether the I/O handle reads/writes binary data (<see langword="true"/>) or strings/characters (<see langword="false"/>) from/to the file
		/// </summary>
		public bool BinaryModeActive{
			get => (settings & 0x01) != 0;
			set{
				if(HandleIsActive)
					throw new InvalidOperationException("Binary/Stream setting can only be modified while an I/O handle is inactive");

				settings = (byte)(value ? settings | 0x01 : settings & ~0x01);
			}
		}

		/// <summary>
		/// Whether the I/O handle writes newlines to the file.  Only valid if <seealso cref="BinaryModeActive"/> is <see langword="false"/>
		/// </summary>
		public bool WriteNewlines{
			get => (settings & 0x02) != 0;
			set => settings = (byte)(value ? settings | 0x02 : settings & ~0x02);
		}

		/// <summary>
		/// Whether the I/O handle writes to (<see langword="true"/>) or reads from (<see langword="false"/>) the file
		/// </summary>
		public bool WriteToStream{
			get => (settings & 0x04) != 0;
			set{
				if(HandleIsActive)
					throw new InvalidOperationException("Reading/Writing setting can only be modified while an I/O handle is inactive");

				settings = (byte)(value ? settings | 0x04 : settings & ~0x04);
			}
		}

		public bool HandleIsActive => handle is not null;

		public void Begin(Opcode.FunctionContext context){
			if(HandleIsActive)
				throw new InvalidOperationException("I/O handle was already active");

			if(file is null)
				throw new InvalidOperationException("I/O handle does not have a destination file set"
					+ ExceptionHelper.GetContextString(context));

			if(mode is not FileMode fMode)
				throw new InvalidOperationException("I/O handle did not have a file access mode set"
					+ ExceptionHelper.GetContextString(context));

			Stream stream = File.Open(file, fMode);

			if(BinaryModeActive){
				if(WriteToStream)
					handle = new BinaryWriter(stream);
				else
					handle = new BinaryReader(stream);
			}else{
				if(WriteToStream)
					handle = new StreamWriter(stream);
				else
					handle = new StreamReader(stream);
			}
		}

		public void Close(Opcode.FunctionContext context){
			if(HandleIsActive)
				throw new InvalidOperationException("I/O handle is already deactivated");

			(handle as IDisposable)?.Dispose();  //Calls Close() on the used stream/binary reader/writer types
			handle = null;
		}

		public void Seek(long offset, SeekOrigin origin, Opcode.FunctionContext context){
			if(!HandleIsActive)
				throw new InvalidOperationException("I/O handle was not active"
					+ ExceptionHelper.GetContextString(context));

			switch(handle){
				case BinaryWriter bw:
					bw.BaseStream.Seek(offset, origin);
					break;
				case BinaryReader br:
					br.BaseStream.Seek(offset, origin);
					break;
				case StreamWriter sw:
					sw.BaseStream.Seek(offset, origin);
					break;
				case StreamReader sr:
					sr.BaseStream.Seek(offset, origin);
					break;
				default:
					throw new InvalidOperationException("Internal Chips Error -- invalid I/O handle state (handle type unknown)"
						+ ExceptionHelper.GetContextString(context));
			}
		}

		public object? Read(string chipsType, Opcode.FunctionContext context){
			if(!HandleIsActive)
				throw new InvalidOperationException("I/O handle was not active"
					+ ExceptionHelper.GetContextString(context));

			if(chipsType == "null")
				throw new InvalidOperationException("Null cannot be used as a type in this context"
					+ ExceptionHelper.GetContextString(context));

			if(BinaryModeActive){
				if(handle is not BinaryReader br)
					throw new InvalidOperationException("I/O stream was not set to \"binary reading\""
						+ ExceptionHelper.GetContextString(context));

				//Read using the byte representations
				return ReadObject(br, TypeTracking.GetTypeCode(TypeTracking.GetCSharpType(chipsType)!), context);
			}else{
				if(handle is not StreamReader sr)
					throw new InvalidOperationException("I/O stream was not set to \"stream reading\""
						+ ExceptionHelper.GetContextString(context));
				
				//Read strings/chars
				int cRead;
				return chipsType switch {
					"str" => sr.ReadLine(),
					"char" => (cRead = sr.Read()) == -1 ? null : (char)cRead,
					_ => throw new InvalidOperationException($"Type \"{chipsType}\" is either not supported by stream reading or does not exist"),
				};
			}
		}

		public void Write(object? obj, Opcode.FunctionContext context){
			if(!HandleIsActive)
				throw new InvalidOperationException("I/O handle was not active"
					+ ExceptionHelper.GetContextString(context));

			if(BinaryModeActive){
				if(handle is not BinaryWriter bw)
					throw new InvalidOperationException("I/O stream was not set to \"binary writing\""
						+ ExceptionHelper.GetContextString(context));

				WriteObject(bw, obj, context);
			}else{
				if(handle is not StreamWriter sr)
					throw new InvalidOperationException("I/O stream was not set to \"stream writing\""
						+ ExceptionHelper.GetContextString(context));

				string str = obj?.ToString() ?? "";

				if(WriteNewlines)
					sr.WriteLine(str);
				else
					sr.WriteLine(str);
			}
		}

		private object? ReadObject(BinaryReader br, Utility.TypeCode code, Opcode.FunctionContext context){
			switch(code){
				case Utility.TypeCode.Null:
					return null;
				case Utility.TypeCode.Int32:
					return br.ReadInt32();
				case Utility.TypeCode.Int8:
					return br.ReadSByte();
				case Utility.TypeCode.Int16:
					return br.ReadInt16();
				case Utility.TypeCode.Int64:
					return br.ReadInt64();
				case Utility.TypeCode.Uint32:
					return br.ReadUInt32();
				case Utility.TypeCode.Uint8:
					return br.ReadByte();
				case Utility.TypeCode.Uint16:
					return br.ReadUInt16();
				case Utility.TypeCode.Uint64:
					return br.ReadUInt64();
				case Utility.TypeCode.BigInt:
					return new BigInteger((ReadObject(br, Utility.TypeCode.Array, context) as byte[])!);  //Serialized as a byte[]
				case Utility.TypeCode.Float32:
					return br.ReadSingle();
				case Utility.TypeCode.Float64:
					return br.ReadDouble();
				case Utility.TypeCode.Float128:
					return br.ReadDecimal();
				case Utility.TypeCode.Obj:
					throw new InvalidOperationException("Type \"obj\" cannot be deserlialized"
						+ ExceptionHelper.GetContextString(context));
				case Utility.TypeCode.Char:
					return br.ReadChar();
				case Utility.TypeCode.Str:
					return br.ReadString();
				case Utility.TypeCode.Indexer:
					return new Indexer(br.ReadInt32());
				case Utility.TypeCode.Array:
					Utility.TypeCode elemCode = (Utility.TypeCode)br.ReadByte();
					int jaggedNestDepth = br.ReadByte();
					int count = br.Read7BitEncodedInt();

					Type? elemType = TypeTracking.GetCSharpType(elemCode);
					while(jaggedNestDepth-->0)
						elemType = elemType!.MakeArrayType();

					Array arr = Array.CreateInstance(elemType!, count);

					for(int i = 0; i < count; i++){
						object? obj = ReadObject(br, elemCode, context);
						arr.SetValue(obj, i);
					}
					
					return arr;
				case Utility.TypeCode.Range:
					int start = br.ReadInt32();
					int end = br.ReadInt32();

					return new Types.Range(start, end);
				case Utility.TypeCode.List:
					int capacity = br.Read7BitEncodedInt();

					List list = new(capacity);
					for(int i = 0; i < capacity; i++)
						list[i] = ReadObject(br, (Utility.TypeCode)br.ReadByte(), context);
					
					return list;
				case Utility.TypeCode.Time:
					return new TimeSpan(br.ReadInt64());
				case Utility.TypeCode.Set:
					int setCount = br.Read7BitEncodedInt();
					object[] setArr = new object[setCount];

					for(int i = 0; i < setCount; i++)
						setArr[i] = ReadObject(br, (Utility.TypeCode)br.ReadByte(), context)!;

					return new ArithmeticSet(setArr);
				case Utility.TypeCode.Date:
					return new DateTime(br.ReadInt64());
				case Utility.TypeCode.Regex:
					return new Types.Regex(br.ReadString());
				case Utility.TypeCode.Bool:
					return br.ReadBoolean();
				case Utility.TypeCode.Rand:
					int randCount = br.Read7BitEncodedInt();
					int[] randArr = new int[randCount];

					for(int i = 0; i < randCount; i++)
						randArr[i] = br.ReadInt32();

					Random rand = new();

					ReflectionGetters.Random_SeedArray[rand] = randArr;
					ReflectionGetters.Random_inext[rand] = br.ReadInt32();
					ReflectionGetters.Random_inextp[rand] = br.ReadInt32();
					
					return rand;
				case Utility.TypeCode.Complex:
					return new Complex(br.ReadDouble(), br.ReadDouble());
				case Utility.TypeCode.UserDefined:
					string asmAndType = br.ReadString();
					if(!asmAndType.Contains("::"))
						throw new InvalidOperationException($"Unkown user-defined type: \"{asmAndType}\""
							+ ExceptionHelper.GetContextString(context));

					string[] split = asmAndType.Split("::");
					Type udType = TypeTracking.GetType(split[1], Assembly.Load(split[0]), out _, throwOnNotFound: false)!;

					IChipsStruct ud = Activator.CreateInstance(udType) as IChipsStruct
						?? throw new InvalidOperationException($"Type was not a user-defined Chips type: \"{asmAndType}\""
							+ ExceptionHelper.GetContextString(context));

					int byteCount = br.Read7BitEncodedInt();
					ud.FromByteArray(br.ReadBytes(byteCount));

					return ud;
				case Utility.TypeCode.Float16:
					return br.ReadHalf();
				default:
					throw new InvalidOperationException("Unknown typecode: " + code
						+ ExceptionHelper.GetContextString(context));
			}
		}

		private void WriteObject(BinaryWriter bw, object? obj, Opcode.FunctionContext context){
			var code = TypeTracking.GetTypeCode(obj);
			bw.Write((byte)code);

			if(code == Utility.TypeCode.Null)
				return;

			switch(obj){
				case int i:
					bw.Write(i);
					break;
				case sbyte sb:
					bw.Write(sb);
					break;
				case short sh:
					bw.Write(sh);
					break;
				case long l:
					bw.Write(l);
					break;
				case uint u:
					bw.Write(u);
					break;
				case byte ub:
					bw.Write(ub);
					break;
				case ushort us:
					bw.Write(us);
					break;
				case ulong ul:
					bw.Write(ul);
					break;
				case BigInteger big:
					WriteObject(bw, big.ToByteArray(), context);
					break;
				case float f:
					bw.Write(f);
					break;
				case double d:
					bw.Write(d);
					break;
				case decimal dm:
					bw.Write(dm);
					break;
				case char c:
					bw.Write(c);
					break;
				case string str:
					bw.Write(str);
					break;
				case Indexer idx:
					bw.Write(idx.value);
					break;
				case Array arr:
					Type? type = arr.GetType().GetElementType(), lastValidType = type;

					//Record the jagged array depth - 1 and the innermost type
					int jaggedNestDepth = 0;
					while(type?.GetElementType()?.IsArray ?? false){
						jaggedNestDepth++;
						type = type.GetElementType();

						if(type is not null)
							lastValidType = type;
					}
					bw.Write((byte)TypeTracking.GetTypeCode(lastValidType!));
					bw.Write((byte)jaggedNestDepth);

					bw.Write7BitEncodedInt(arr.Length);

					for(int i = 0; i < arr.Length; i++)
						WriteObject(bw, arr.GetValue(i), context);
					break;
				case Types.Range range:
					bw.Write(range.start);
					bw.Write(range.end);
					break;
				case List list:
					bw.Write7BitEncodedInt(list.Capacity);

					for(int i = 0; i < list.Capacity; i++)
						WriteObject(bw, list[i], context);
					break;
				case TimeSpan time:
					bw.Write(time.Ticks);
					break;
				case ArithmeticSet set:
					object[] setArr = set.ToArray();

					bw.Write7BitEncodedInt(setArr.Length);

					for(int i = 0; i < setArr.Length; i++)
						WriteObject(bw, setArr[i], context);
					break;
				case DateTime date:
					bw.Write(date.Ticks);
					break;
				case Types.Regex regex:
					bw.Write(regex.ToString());
					break;
				case bool b:
					bw.Write(b);
					break;
				case Random r:
					var seedArr = (ReflectionGetters.Random_SeedArray[r] as int[])!;

					bw.Write7BitEncodedInt(seedArr.Length);
					for(int i = 0; i < seedArr.Length; i++)
						bw.Write(seedArr[i]);
					
					bw.Write((int)ReflectionGetters.Random_inext[r]!);
					bw.Write((int)ReflectionGetters.Random_inextp[r]!);
					break;
				case Complex complex:
					bw.Write(complex.Real);
					bw.Write(complex.Imaginary);
					break;
				case IChipsStruct ud:
					Type udType = ud.GetType();
					bw.Write(udType.Assembly.GetName().Name + "::" + udType.FullName!);

					byte[] udArr = ud.ToByteArray();

					bw.Write7BitEncodedInt(udArr.Length);
					bw.Write(udArr);
					break;
				case Half h:
					bw.Write(h);
					break;
				default:
					if(code == Utility.TypeCode.Obj)
						throw new InvalidOperationException("Type \"obj\" cannot be serlialized"
							+ ExceptionHelper.GetContextString(context));
					throw new InvalidOperationException("Unknown typecode: " + code
						+ ExceptionHelper.GetContextString(context));
			}
		}
	}
}
