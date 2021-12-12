using Chips.Core.Meta;
using Chips.Core.Types;
using Chips.Core.Types.NumberProcessing;
using Chips.Core.Types.UserDefined;
using Chips.Core.Utility;
using System.Numerics;

namespace Chips.Core.Specifications{
	public unsafe partial class Opcode{
		internal static class Functions{
			#region Functions - A
			public static void Abs(FunctionContext context){
				if(ValueConverter.BoxToUnderlyingType(Metadata.Registers.A.Data) is not INumber a)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not a number value", context);

				Metadata.Registers.A.Data = a.Abs().Value;
				CheckZeroFlag_RegisterA(checkIntegers: true, checkFloats: true);
			}

			public static void Acos(FunctionContext context){
				if(ValueConverter.BoxToUnderlyingType(Metadata.Registers.A.Data) is not IFloat a)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not a floating-point number value", context);

				Metadata.Registers.A.Data = (a.Acos() as INumber)!.Value;
				CheckZeroFlag_RegisterA(checkFloats: true);
			}

			public static void Acsh(FunctionContext context){
				if(ValueConverter.BoxToUnderlyingType(Metadata.Registers.A.Data) is not IFloat a)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not a floating-point number value", context);

				Metadata.Registers.A.Data = (a.Acosh() as INumber)!.Value;
				CheckZeroFlag_RegisterA(checkFloats: true);
			}

			public static void Add(FunctionContext context){
				if(ValueConverter.BoxToUnderlyingType(Metadata.Registers.A.Data) is not INumber a)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not a number value", context);
				if(ValueConverter.BoxToUnderlyingType(context.args[0]) is not INumber arg)
					throw new InvalidOpcodeArgumentException(0, "Value was not a number value", context);

				Metadata.Registers.A.Data = a.Add(arg).Value;
				CheckZeroFlag_RegisterA(checkIntegers: true, checkFloats: true);
			}

			public static void Aems(FunctionContext context){
				Metadata.Registers.A.Data = ArithmeticSet.EmptySet;

				Metadata.Flags.Zero = true;
			}

			public static void And(FunctionContext context){
				if(ValueConverter.BoxToUnderlyingType(Metadata.Registers.A.Data) is not IInteger a)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not an integer value", context);
				if(ValueConverter.BoxToUnderlyingType(context.args[0]) is not IInteger arg)
					throw new InvalidOpcodeArgumentException(0, "Value was not an integer", context);

				Metadata.Registers.A.Data = (a.And(arg) as INumber)!.Value;
				CheckZeroFlag_RegisterA(checkIntegers: true);
			}

			public static void Art(FunctionContext context){
				if(ValueConverter.BoxToUnderlyingType(Metadata.Registers.A.Data) is not IFloat a)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not a floating-point number value", context);
				if(ValueConverter.BoxToUnderlyingType(context.args[0]) is not IFloat arg)
					throw new InvalidOpcodeArgumentException(0, "Value was not a floating-point number", context);

				Metadata.Registers.A.Data = (a.Root(arg) as INumber)!.Value;
				CheckZeroFlag_RegisterA(checkFloats: true);
			}

			public static void Asin(FunctionContext context){
				if(ValueConverter.BoxToUnderlyingType(Metadata.Registers.A.Data) is not IFloat a)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not a floating-point number value", context);

				Metadata.Registers.A.Data = (a.Asin() as INumber)!.Value;
				CheckZeroFlag_RegisterA(checkFloats: true);
			}

			public static void Asl(FunctionContext context){
				if(ValueConverter.BoxToUnderlyingType(Metadata.Registers.A.Data) is not IInteger a)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not an integer value", context);

				Metadata.Registers.A.Data = (a.ArithmeticShiftLeft() as INumber)!.Value;
				CheckZeroFlag_RegisterA(checkIntegers: true);
			}

			public static void Asnh(FunctionContext context){
				if(ValueConverter.BoxToUnderlyingType(Metadata.Registers.A.Data) is not IFloat a)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not a floating-point number value", context);

				Metadata.Registers.A.Data = (a.Asinh() as INumber)!.Value;
				CheckZeroFlag_RegisterA(checkFloats: true);
			}

			public static void Asr(FunctionContext context){
				if(ValueConverter.BoxToUnderlyingType(Metadata.Registers.A.Data) is not IInteger a)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not an integer value", context);

				Metadata.Registers.A.Data = (a.ArithmeticShiftRight() as INumber)!.Value;
				CheckZeroFlag_RegisterA(checkIntegers: true);
			}

			public static void Atan(FunctionContext context){
				if(ValueConverter.BoxToUnderlyingType(Metadata.Registers.A.Data) is not IFloat a)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not a floating-point number value", context);

				Metadata.Registers.A.Data = (a.Atan() as INumber)!.Value;
				CheckZeroFlag_RegisterA(checkFloats: true);
			}

			public static void Atnh(FunctionContext context){
				if(ValueConverter.BoxToUnderlyingType(Metadata.Registers.A.Data) is not IFloat a)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not a floating-point number value", context);

				Metadata.Registers.A.Data = (a.Atanh() as INumber)!.Value;
				CheckZeroFlag_RegisterA(checkFloats: true);
			}

			public static void Atnt(FunctionContext context){
				if(ValueConverter.BoxToUnderlyingType(Metadata.Registers.A.Data) is not IFloat a)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not a floating-point number value", context);
				if(ValueConverter.BoxToUnderlyingType(context.args[0]) is not IFloat arg)
					throw new InvalidOpcodeArgumentException(0, "Value was not a floating-point number", context);

				Metadata.Registers.A.Data = (a.Atan2(arg) as INumber)!.Value;
				CheckZeroFlag_RegisterA(checkFloats: true);
			}
			#endregion

			#region Functions - B
			public static void Br(FunctionContext context)
				=> throw new InvalidOperationException("Branching opcodes should not be invoked directly");

			public static void Blg(FunctionContext context){
				if(ValueConverter.BoxToUnderlyingType(Metadata.Registers.A.Data) is not IFloat a)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not a floating-point number value", context);

				Metadata.Registers.A.Data = (a.Log2() as INumber)!.Value;
				CheckZeroFlag_RegisterA(checkFloats: true);
			}

			public static void Bin(FunctionContext context){
				if(ValueConverter.BoxToUnderlyingType(Metadata.Registers.A.Data) is not IInteger a)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not an integer value", context);

				Metadata.Registers.S.Data = a.BinaryRepresentation(false);
				CheckZeroFlag_RegisterS();
			}

			public static void Binz(FunctionContext context){
				if(ValueConverter.BoxToUnderlyingType(Metadata.Registers.A.Data) is not IInteger a)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not an integer value", context);

				Metadata.Registers.S.Data = a.BinaryRepresentation(true);
				CheckZeroFlag_RegisterS();
			}

			public static void Bit(FunctionContext context){
				if(ValueConverter.BoxToUnderlyingType(Metadata.Registers.A.Data) is not IInteger a)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not an integer value", context);
				if(ValueConverter.BoxToUnderlyingType(context.args[0]) is not IInteger arg)
					throw new InvalidOpcodeArgumentException(0, "Value was not an integer", context);

				Metadata.Registers.A.Data = (a.GetBit(arg) as INumber)!.Value;
				CheckZeroFlag_RegisterA(checkIntegers: true);
			}

			public static void Bits(FunctionContext context){
				if(ValueConverter.BoxToUnderlyingType(Metadata.Registers.A.Data) is not IFloat a)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not a floating-point number value", context);

				Metadata.Registers.A.Data = (a.GetBits() as INumber)!.Value;
				CheckZeroFlag_RegisterA(checkFloats: true);
			}
			#endregion

			#region Functions - C
			public static void Call(FunctionContext context)
				=> throw new InvalidOperationException("Call opcode should not be called directly");

			public static void Caps(FunctionContext context){
				if(!OperatingSystem.IsWindows())
					throw new InvalidOperationException("Console opcodes are only supported on Windows");

				Metadata.Registers.A.Data = Console.CapsLock;
				CheckZeroFlag_RegisterA(checkIntegers: true);
			}

			public static void Cast(FunctionContext context){
				if(context.args[0] is not Type type)
					throw new InvalidOpcodeArgumentException(0, "Value was not a type instance", context);

				// TODO: more conversions

				object? data = Metadata.Registers.A.Data;
				if(ValueConverter.BoxToUnderlyingType(data) is not INumber number){
					//Check for conversions between the various types
					switch(data){
						case Array array:
							if(type == typeof(string) && array is char[] charArray)
								Metadata.Registers.A.Data = new string(charArray);
							else
								goto castFail;
							break;
						case string str:
							if(type == typeof(char[]))
								Metadata.Registers.A.Data = str.ToCharArray();
							else
								goto castFail;

							Metadata.Flags.Conversion = true;
							break;
						case List list:
							if(type == typeof(object[]))
								Metadata.Registers.A.Data = list.ToArray();
							else
								goto castFail;
							break;
					}

					CheckZeroFlag_RegisterA(checkCollections: true, checkStrings: true);
				}else{
					if(type == typeof(sbyte))
						Metadata.Registers.A.Data = ValueConverter.CastToSByte_T(number);
					else if(type == typeof(short))
						Metadata.Registers.A.Data = ValueConverter.CastToInt16_T(number);
					else if(type == typeof(int))
						Metadata.Registers.A.Data = ValueConverter.CastToInt32_T(number);
					else if(type == typeof(long))
						Metadata.Registers.A.Data = ValueConverter.CastToInt64_T(number);
					else if(type == typeof(byte))
						Metadata.Registers.A.Data = ValueConverter.CastToByte_T(number);
					else if(type == typeof(ushort))
						Metadata.Registers.A.Data = ValueConverter.CastToUInt16_T(number);
					else if(type == typeof(uint))
						Metadata.Registers.A.Data = ValueConverter.CastToUInt32_T(number);
					else if(type == typeof(ulong))
						Metadata.Registers.A.Data = ValueConverter.CastToUInt64_T(number);
					else if(type == typeof(float))
						Metadata.Registers.A.Data = ValueConverter.CastToSingle_T(number);
					else if(type == typeof(double))
						Metadata.Registers.A.Data = ValueConverter.CastToDouble_T(number);
					else if(type == typeof(decimal))
						Metadata.Registers.A.Data = ValueConverter.CastToDecimal_T(number);
					else if(type == typeof(Half))
						Metadata.Registers.A.Data = ValueConverter.CastToHalf_T(number);
					else if(type == typeof(Complex))
						Metadata.Registers.A.Data = ValueConverter.CastToComplex_T(number);

					CheckZeroFlag_RegisterA(checkIntegers: true, checkFloats: true);
				}

				return;
castFail:
				throw new InvalidOpcodeArgumentException(0, $"Cannot cast a value of type <{TypeTracking.GetChipsType(data, throwOnNotFound: false)}> to type <{TypeTracking.GetChipsType(type, throwOnNotFound: false)}>", context);
			}

			public static void Cclb(FunctionContext context){
				if(!OperatingSystem.IsWindows())
					throw new InvalidOperationException("Console opcodes are only supported on Windows");

				if(Metadata.Flags.PropertyAccess){
					Metadata.Registers.A.Data = (int)Console.BackgroundColor;
					CheckZeroFlag_RegisterA(checkIntegers: true);
				}else{
					if(ValueConverter.BoxToUnderlyingType(Metadata.Registers.A.Data) is not IInteger)
						throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not an integer value", context);

					int color;
					if(ValueConverter.AsSignedInteger(Metadata.Registers.A.Data) is long l)
						color = (int)l;
					else if(ValueConverter.AsUnsignedInteger(Metadata.Registers.A.Data) is ulong u)
						color = (int)u;
					else
						throw new InvalidOperationException($"Internal Chips Error -- {Metadata.Registers.A} contained an integer but also did not contain an integer");

					if(color >= 0 && color <= 15)
						Console.BackgroundColor = (ConsoleColor)color;
					else
						throw new InvalidRegisterValueException("The value in " + Metadata.Registers.A.ToString() + " exceeded the expected values (0 to 15, inclusive)", context);
				}
			}

			public static void Cclf(FunctionContext context){
				if(!OperatingSystem.IsWindows())
					throw new InvalidOperationException("Console opcodes are only supported on Windows");

				if(Metadata.Flags.PropertyAccess){
					Metadata.Registers.A.Data = (int)Console.ForegroundColor;
					CheckZeroFlag_RegisterA(checkIntegers: true);
				}else{
					if(ValueConverter.BoxToUnderlyingType(Metadata.Registers.A.Data) is not IInteger)
						throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not an integer value", context);

					int color;
					if(ValueConverter.AsSignedInteger(Metadata.Registers.A.Data) is long l)
						color = (int)l;
					else if(ValueConverter.AsUnsignedInteger(Metadata.Registers.A.Data) is ulong u)
						color = (int)u;
					else
						throw new InvalidOperationException($"Internal Chips Error -- {Metadata.Registers.A} contained an integer but also did not contain an integer");

					if(color >= 0 && color <= 15)
						Console.ForegroundColor = (ConsoleColor)color;
					else
						throw new InvalidRegisterValueException("The value in " + Metadata.Registers.A.ToString() + " exceeded the expected values (0 to 15, inclusive)", context);
				}
			}

			public static void Ceil(FunctionContext context){
				if(ValueConverter.BoxToUnderlyingType(Metadata.Registers.A.Data) is not IFloat a)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not a floating-point number value", context);

				Metadata.Registers.A.Data = a.Ceiling().Value;
				CheckZeroFlag_RegisterA(checkFloats: true);
			}

			public static void Ceq(FunctionContext context){
				object? obj = Metadata.Registers.A.Data, obj2 = context.args[0];

				if(ValueConverter.BoxToUnderlyingType(obj) is INumber number && ValueConverter.BoxToUnderlyingType(obj2) is INumber number2){
					if(ArithmeticSet.Number.CompareNumbers(number.Value, number2.Value) == 0)
						Metadata.Flags.Comparison = true;
				}else if(obj is ArithmeticSet set && obj2 is ArithmeticSet set2){
					if(!ArithmeticSet.Difference(set, set2).IsEmptySet)
						Metadata.Flags.Comparison = true;
				}else if(obj is Types.Range range && obj2 is Types.Range range2){
					if(range.start == range2.start && range.end == range2.end)
						Metadata.Flags.Comparison = true;
				}else
					throw new InvalidOpcodeArgumentException(0, $"Cannot compare equality between a <{TypeTracking.GetChipsType(obj, throwOnNotFound: false)}> and a <{TypeTracking.GetChipsType(obj2, throwOnNotFound: false)}>", context);
			}

			public static void Cge(FunctionContext context){
				object? obj = Metadata.Registers.A.Data, obj2 = context.args[0];

				if(ValueConverter.BoxToUnderlyingType(obj) is INumber number && ValueConverter.BoxToUnderlyingType(obj2) is INumber number2){
					if(ArithmeticSet.Number.CompareNumbers(number.Value, number2.Value) >= 0)
						Metadata.Flags.Comparison = true;
				}else
					throw new InvalidOpcodeArgumentException(0, "Opcode \"cge\" can only be used with number values", context);
			}

			public static void Cgt(FunctionContext context){
				object? obj = Metadata.Registers.A.Data, obj2 = context.args[0];

				if(ValueConverter.BoxToUnderlyingType(obj) is INumber number && ValueConverter.BoxToUnderlyingType(obj2) is INumber number2){
					if(ArithmeticSet.Number.CompareNumbers(number.Value, number2.Value) > 0)
						Metadata.Flags.Comparison = true;
				}else
					throw new InvalidOpcodeArgumentException(0, "Opcode \"cgt\" can only be used with number values", context);
			}

			public static void Clc(FunctionContext context){
				Metadata.Flags.Carry = false;
			}

			public static void Cle(FunctionContext context){
				object? obj = Metadata.Registers.A.Data, obj2 = context.args[0];

				if(ValueConverter.BoxToUnderlyingType(obj) is INumber number && ValueConverter.BoxToUnderlyingType(obj2) is INumber number2){
					if(ArithmeticSet.Number.CompareNumbers(number.Value, number2.Value) <= 0)
						Metadata.Flags.Comparison = true;
				}else
					throw new InvalidOpcodeArgumentException(0, "Opcode \"cle\" can only be used with number values", context);
			}

			public static void Cln(FunctionContext context){
				Metadata.Flags.Conversion = false;
			}

			public static void Clo(FunctionContext context){
				Metadata.Flags.Comparison = false;
			}

			public static void Clp(FunctionContext context){
				Metadata.Flags.PropertyAccess = false;
			}

			public static void Clr(FunctionContext context){
				Metadata.Flags.RegexSuccess = false;
			}

			public static void Cls(FunctionContext context){
				if(!OperatingSystem.IsWindows())
					throw new InvalidOperationException("Console opcodes are only supported on Windows");

				Console.Clear();
			}

			public static void Clt(FunctionContext context){
				object? obj = Metadata.Registers.A.Data, obj2 = context.args[0];

				if(ValueConverter.BoxToUnderlyingType(obj) is INumber number && ValueConverter.BoxToUnderlyingType(obj2) is INumber number2){
					if(ArithmeticSet.Number.CompareNumbers(number.Value, number2.Value) < 0)
						Metadata.Flags.Comparison = true;
				}else
					throw new InvalidOpcodeArgumentException(0, "Opcode \"clt\" can only be used with number values", context);
			}

			public static void Clz(FunctionContext context){
				Metadata.Flags.Zero = false;
			}

			public static void Cnrb(FunctionContext context){
				if(!OperatingSystem.IsWindows())
					throw new InvalidOperationException("Console opcodes are only supported on Windows");

				ConsoleColor color = Console.ForegroundColor;
				Console.ResetColor();
				Console.ForegroundColor = color;
			}

			public static void Cnrf(FunctionContext context){
				if(!OperatingSystem.IsWindows())
					throw new InvalidOperationException("Console opcodes are only supported on Windows");

				ConsoleColor color = Console.BackgroundColor;
				Console.ResetColor();
				Console.BackgroundColor = color;
			}

			public static void Cnwh(FunctionContext context){
				if(!OperatingSystem.IsWindows())
					throw new InvalidOperationException("Console opcodes are only supported on Windows");

				if(Metadata.Flags.PropertyAccess){
					Metadata.Registers.A.Data = Console.WindowHeight;
					CheckZeroFlag_RegisterA(checkIntegers: true);
				}else{
					if(ValueConverter.BoxToUnderlyingType(Metadata.Registers.A.Data) is not Int32_T i)
						throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not an <i32> value", context);

					Console.WindowHeight = (int)i.Value;
				}
			}

			public static void Cnww(FunctionContext context){
				if(!OperatingSystem.IsWindows())
					throw new InvalidOperationException("Console opcodes are only supported on Windows");

				if(Metadata.Flags.PropertyAccess){
					Metadata.Registers.A.Data = Console.WindowWidth;
					CheckZeroFlag_RegisterA(checkIntegers: true);
				}else{
					if(ValueConverter.BoxToUnderlyingType(Metadata.Registers.A.Data) is not Int32_T i)
						throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not an <i32> value", context);

					Console.WindowWidth = (int)i.Value;
				}
			}

			public static void Conh(FunctionContext context){
				if(!OperatingSystem.IsWindows())
					throw new InvalidOperationException("Console opcodes are only supported on Windows");

				if(Metadata.Flags.PropertyAccess){
					Metadata.Registers.A.Data = Console.BufferHeight;
					CheckZeroFlag_RegisterA(checkIntegers: true);
				}else{
					if(ValueConverter.BoxToUnderlyingType(Metadata.Registers.A.Data) is not Int32_T i)
						throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not an <i32> value", context);

					Console.BufferHeight = (int)i.Value;
				}
			}

			public static void Cont(FunctionContext context){
				if(!OperatingSystem.IsWindows())
					throw new InvalidOperationException("Console opcodes are only supported on Windows");

				if(Metadata.Flags.PropertyAccess){
					Metadata.Registers.S.Data = Console.Title;
					CheckZeroFlag_RegisterS();
				}else{
					if(Metadata.Registers.S.Data is not string s)
						throw new InvalidRegisterTypeException(Metadata.Registers.S.ToString() + " was not a <str> value", context);

					Console.Title = s;
				}
			}

			public static void Conr(FunctionContext context){
				if(!OperatingSystem.IsWindows())
					throw new InvalidOperationException("Console opcodes are only supported on Windows");

				Console.ResetColor();
			}

			public static void Conw(FunctionContext context){
				if(!OperatingSystem.IsWindows())
					throw new InvalidOperationException("Console opcodes are only supported on Windows");

				if(Metadata.Flags.PropertyAccess){
					Metadata.Registers.A.Data = Console.BufferWidth;
					CheckZeroFlag_RegisterA(checkIntegers: true);
				}else{
					if(ValueConverter.BoxToUnderlyingType(Metadata.Registers.A.Data) is not Int32_T i)
						throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not an <i32> value", context);

					Console.BufferWidth = (int)i.Value;
				}
			}
			
			public static void Cpcj(FunctionContext context){
				if(Metadata.Registers.A.Data is not Complex c)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not a <~cplx> value", context);

				Metadata.Registers.A.Data = Complex.Conjugate(c);
				CheckZeroFlag_RegisterA(checkFloats: true);
			}

			public static void Cpco(FunctionContext context){
				Metadata.Registers.A.Data = Complex.ImaginaryOne;
			}

			public static void Cpi(FunctionContext context){
				if(Metadata.Registers.A.Data is not Complex c)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not a <~cplx> value", context);

				Metadata.Registers.A.Data = c.Imaginary;
				CheckZeroFlag_RegisterA(checkFloats: true);
			}

			public static void Cpnr(FunctionContext context){
				if(Metadata.Registers.A.Data is not Complex c)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not a <~cplx> value", context);

				Metadata.Registers.A.Data = new Complex(-c.Real, c.Imaginary);
				CheckZeroFlag_RegisterA(checkFloats: true);
			}

			public static void Cpo(FunctionContext context){
				Metadata.Registers.A.Data = new Complex(1, 1);
			}

			public static void Cpr(FunctionContext context){
				if(Metadata.Registers.A.Data is not Complex c)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not a <~cplx> value", context);

				Metadata.Registers.A.Data = c.Real;
				CheckZeroFlag_RegisterA(checkFloats: true);
			}

			public static void Cpro(FunctionContext context){
				Metadata.Registers.A.Data = Complex.One;
			}

			public static void Cprv(FunctionContext context){
				if(Metadata.Registers.A.Data is not Complex c)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not a <~cplx> value", context);

				Metadata.Registers.A.Data = new Complex(c.Imaginary, c.Real);
				CheckZeroFlag_RegisterA(checkFloats: true);
			}

			public static void Cpz(FunctionContext context){
				Metadata.Registers.A.Data = Complex.Zero;
				Metadata.Flags.Zero = true;
			}

			public static void Csrv(FunctionContext context){
				if(!OperatingSystem.IsWindows())
					throw new InvalidOperationException("Console opcodes are only supported on Windows");

				if(Metadata.Flags.PropertyAccess){
					Metadata.Registers.A.Data = Console.CursorVisible;
					CheckZeroFlag_RegisterA(checkIntegers: true);
				}else{
					if(Metadata.Registers.A.Data is not bool b)
						throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not a <bool> value", context);

					Console.CursorVisible = b;
				}
			}

			public static void Csrx(FunctionContext context){
				if(!OperatingSystem.IsWindows())
					throw new InvalidOperationException("Console opcodes are only supported on Windows");

				if(Metadata.Flags.PropertyAccess){
					Metadata.Registers.A.Data = Console.CursorLeft;
					CheckZeroFlag_RegisterA(checkIntegers: true);
				}else{
					if(ValueConverter.BoxToUnderlyingType(Metadata.Registers.A.Data) is not Int32_T i)
						throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not an <i32> value", context);

					Console.CursorLeft = (int)i.Value;
				}
			}

			public static void Csry(FunctionContext context){
				if(!OperatingSystem.IsWindows())
					throw new InvalidOperationException("Console opcodes are only supported on Windows");

				if(Metadata.Flags.PropertyAccess){
					Metadata.Registers.A.Data = Console.CursorTop;
					CheckZeroFlag_RegisterA(checkIntegers: true);
				}else{
					if(ValueConverter.BoxToUnderlyingType(Metadata.Registers.A.Data) is not Int32_T i)
						throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not an <i32> value", context);

					Console.CursorTop = (int)i.Value;
				}
			}
			#endregion

			#region Functions - D
			public static void Dex(FunctionContext context){
				Metadata.Registers.X.Data = (Metadata.Registers.X.Data as INumber)!.Decrement();
				CheckZeroFlag_RegisterX();
			}

			public static void Dey(FunctionContext context){
				Metadata.Registers.X.Data = (Metadata.Registers.Y.Data as INumber)!.Decrement();
				CheckZeroFlag_RegisterY();
			}

			public static void Div(FunctionContext context){
				if(ValueConverter.BoxToUnderlyingType(Metadata.Registers.A.Data) is not INumber a)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not a number value", context);
				if(ValueConverter.BoxToUnderlyingType(context.args[0]) is not INumber arg)
					throw new InvalidOpcodeArgumentException(0, "Value was not a number value", context);

				Metadata.Registers.A.Data = a.Divide(arg).Value;
				CheckZeroFlag_RegisterA(checkIntegers: true, checkFloats: true);
			}

			public static void Dtad(FunctionContext context){
				if(Metadata.Registers.A.Data is not DateTime d)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not a <~date> value", context);
				if(ValueConverter.BoxToUnderlyingType(context.args[0]) is not INumber arg)
					throw new InvalidOpcodeArgumentException(0, "Value was not a number value", context);

				if((arg = ValueConverter.EnsureObjectCanBeCastToIConvertable(arg!)!) is null)
					throw new InvalidOpcodeArgumentException(0, "Value cannot be a <~cplx> value", context);

				Metadata.Registers.A.Data = d.AddDays((double)ValueConverter.CastToDouble_T(arg).Value);
				CheckZeroFlag_RegisterA(checkIntegers: true);
			}

			public static void Dtah(FunctionContext context){
				if(Metadata.Registers.A.Data is not DateTime d)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not a <~date> value", context);
				if(ValueConverter.BoxToUnderlyingType(context.args[0]) is not INumber arg)
					throw new InvalidOpcodeArgumentException(0, "Value was not a number value", context);

				if((arg = ValueConverter.EnsureObjectCanBeCastToIConvertable(arg!)!) is null)
					throw new InvalidOpcodeArgumentException(0, "Value cannot be a <~cplx> value", context);

				Metadata.Registers.A.Data = d.AddHours((double)ValueConverter.CastToDouble_T(arg).Value);
				CheckZeroFlag_RegisterA(checkIntegers: true);
			}

			public static void Dtai(FunctionContext context){
				if(Metadata.Registers.A.Data is not DateTime d)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not a <~date> value", context);
				if(ValueConverter.BoxToUnderlyingType(context.args[0]) is not INumber arg)
					throw new InvalidOpcodeArgumentException(0, "Value was not a number value", context);

				if((arg = ValueConverter.EnsureObjectCanBeCastToIConvertable(arg!)!) is null)
					throw new InvalidOpcodeArgumentException(0, "Value cannot be a <~cplx> value", context);

				Metadata.Registers.A.Data = d.AddMinutes((double)ValueConverter.CastToDouble_T(arg).Value);
				CheckZeroFlag_RegisterA(checkIntegers: true);
			}

			public static void Dtam(FunctionContext context){
				if(Metadata.Registers.A.Data is not DateTime d)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not a <~date> value", context);
				if(ValueConverter.BoxToUnderlyingType(context.args[0]) is not INumber arg)
					throw new InvalidOpcodeArgumentException(0, "Value was not a number value", context);

				if((arg = ValueConverter.EnsureObjectCanBeCastToIConvertable(arg!)!) is null)
					throw new InvalidOpcodeArgumentException(0, "Value cannot be a <~cplx> value", context);

				Metadata.Registers.A.Data = d.AddMilliseconds((double)ValueConverter.CastToDouble_T(arg).Value);
				CheckZeroFlag_RegisterA(checkIntegers: true);
			}

			public static void Dtao(FunctionContext context){
				if(Metadata.Registers.A.Data is not DateTime d)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not a <~date> value", context);
				if(ValueConverter.BoxToUnderlyingType(context.args[0]) is not INumber arg)
					throw new InvalidOpcodeArgumentException(0, "Value was not a number value", context);

				if((arg = ValueConverter.EnsureObjectCanBeCastToIConvertable(arg!)!) is null)
					throw new InvalidOpcodeArgumentException(0, "Value cannot be a <~cplx> value", context);

				Metadata.Registers.A.Data = d.AddMonths((int)ValueConverter.CastToInt32_T(arg).Value);
				CheckZeroFlag_RegisterA(checkIntegers: true);
			}

			public static void Dtat(FunctionContext context){
				if(Metadata.Registers.A.Data is not DateTime d)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not a <~date> value", context);
				if(ValueConverter.BoxToUnderlyingType(context.args[0]) is not INumber arg)
					throw new InvalidOpcodeArgumentException(0, "Value was not a number value", context);

				if((arg = ValueConverter.EnsureObjectCanBeCastToIConvertable(arg!)!) is null)
					throw new InvalidOpcodeArgumentException(0, "Value cannot be a <~cplx> value", context);

				Metadata.Registers.A.Data = d.AddTicks((long)ValueConverter.CastToInt64_T(arg).Value);
				CheckZeroFlag_RegisterA(checkIntegers: true);
			}

			public static void Dtas(FunctionContext context){
				if(Metadata.Registers.A.Data is not DateTime d)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not a <~date> value", context);
				if(ValueConverter.BoxToUnderlyingType(context.args[0]) is not INumber arg)
					throw new InvalidOpcodeArgumentException(0, "Value was not a number value", context);

				if((arg = ValueConverter.EnsureObjectCanBeCastToIConvertable(arg!)!) is null)
					throw new InvalidOpcodeArgumentException(0, "Value cannot be a <~cplx> value", context);

				Metadata.Registers.A.Data = d.AddSeconds((double)ValueConverter.CastToDouble_T(arg).Value);
				CheckZeroFlag_RegisterA(checkIntegers: true);
			}

			public static void Dtay(FunctionContext context){
				if(Metadata.Registers.A.Data is not DateTime d)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not a <~date> value", context);
				if(ValueConverter.BoxToUnderlyingType(context.args[0]) is not INumber arg)
					throw new InvalidOpcodeArgumentException(0, "Value was not a number value", context);

				if((arg = ValueConverter.EnsureObjectCanBeCastToIConvertable(arg!)!) is null)
					throw new InvalidOpcodeArgumentException(0, "Value cannot be a <~cplx> value", context);

				Metadata.Registers.A.Data = d.AddYears((int)ValueConverter.CastToInt32_T(arg).Value);
				CheckZeroFlag_RegisterA(checkIntegers: true);
			}

			public static void Dtd(FunctionContext context){
				if(Metadata.Registers.A.Data is not DateTime d)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not a <~date> value", context);

				Metadata.Registers.A.Data = d.Day;
				CheckZeroFlag_RegisterA(checkIntegers: true);
			}

			public static void Dte(FunctionContext context){
				Metadata.Registers.A.Data = DateTime.UnixEpoch;
			}

			public static void Dtfm(FunctionContext context){
				if(Metadata.Registers.A.Data is not DateTime d)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not a <~date> value", context);

				Metadata.Registers.S.Data = d.ToString(Metadata.Registers.S.Data as string);
				CheckZeroFlag_RegisterS();
			}

			public static void Dth(FunctionContext context){
				if(Metadata.Registers.A.Data is not DateTime d)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not a <~date> value", context);

				Metadata.Registers.A.Data = d.Hour;
				CheckZeroFlag_RegisterA(checkIntegers: true);
			}

			public static void Dti(FunctionContext context){
				if(Metadata.Registers.A.Data is not DateTime d)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not a <~date> value", context);

				Metadata.Registers.A.Data = d.Minute;
				CheckZeroFlag_RegisterA(checkIntegers: true);
			}

			public static void Dtm(FunctionContext context){
				if(Metadata.Registers.A.Data is not DateTime d)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not a <~date> value", context);

				Metadata.Registers.A.Data = d.Millisecond;
				CheckZeroFlag_RegisterA(checkIntegers: true);
			}

			public static void Dtn(FunctionContext context){
				Metadata.Registers.A.Data = DateTime.Now;
				CheckZeroFlag_RegisterA(checkIntegers: true);
			}

			public static void Dto(FunctionContext context){
				if(Metadata.Registers.A.Data is not DateTime d)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not a <~date> value", context);

				Metadata.Registers.A.Data = d.Month;
				CheckZeroFlag_RegisterA(checkIntegers: true);
			}

			public static void Dtt(FunctionContext context){
				if(Metadata.Registers.A.Data is not DateTime d)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not a <~date> value", context);

				Metadata.Registers.A.Data = d.Ticks;
				CheckZeroFlag_RegisterA(checkIntegers: true);
			}

			public static void Dts(FunctionContext context){
				if(Metadata.Registers.A.Data is not DateTime d)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not a <~date> value", context);

				Metadata.Registers.A.Data = d.Second;
				CheckZeroFlag_RegisterA(checkIntegers: true);
			}

			public static void Dty(FunctionContext context){
				if(Metadata.Registers.A.Data is not DateTime d)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not a <~date> value", context);

				Metadata.Registers.A.Data = d.Year;
				CheckZeroFlag_RegisterA(checkIntegers: true);
			}

			public static void Dup(FunctionContext context){
				Metadata.stack!.Push(Metadata.stack!.Peek());
			}

			public static void Dupd(FunctionContext context){
				object? obj = Metadata.stack!.Peek();

				Metadata.stack.Push(obj switch{
					Array a => a.Clone(),
					List l => new List(l.ToArray()),
					ArithmeticSet s => new ArithmeticSet(s.ToArray()),
					IChipsStruct i => i.Clone(),
					_ => obj
				});
			}
			#endregion
		}
	}
}
