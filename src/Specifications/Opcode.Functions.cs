using Chips.Core.Meta;
using Chips.Core.Types;
using Chips.Core.Types.NumberProcessing;
using Chips.Core.Types.UserDefined;
using Chips.Core.Utility;
using System.Numerics;
using System.Reflection;
using System.Text.RegularExpressions;

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
				=> throw new InvalidOperationException("Call opcode should not be called directly"
						+ ExceptionHelper.GetContextString(context));

			public static void Caps(FunctionContext context){
				if(!OperatingSystem.IsWindows())
					throw new InvalidOperationException("Console opcodes are only supported on Windows"
						+ ExceptionHelper.GetContextString(context));

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
					throw new InvalidOperationException("Console opcodes are only supported on Windows"
						+ ExceptionHelper.GetContextString(context));

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
						throw new InvalidOperationException($"Internal Chips Error -- {Metadata.Registers.A} contained an integer but also did not contain an integer"
							+ ExceptionHelper.GetContextString(context));

					if(color >= 0 && color <= 15)
						Console.BackgroundColor = (ConsoleColor)color;
					else
						throw new InvalidRegisterValueException("The value in " + Metadata.Registers.A.ToString() + " exceeded the expected values (0 to 15, inclusive)", context);
				}
			}

			public static void Cclf(FunctionContext context){
				if(!OperatingSystem.IsWindows())
					throw new InvalidOperationException("Console opcodes are only supported on Windows"
						+ ExceptionHelper.GetContextString(context));

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
						throw new InvalidOperationException($"Internal Chips Error -- {Metadata.Registers.A} contained an integer but also did not contain an integer"
							+ ExceptionHelper.GetContextString(context));

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
					throw new InvalidOperationException("Console opcodes are only supported on Windows"
						+ ExceptionHelper.GetContextString(context));

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
					throw new InvalidOperationException("Console opcodes are only supported on Windows"
						+ ExceptionHelper.GetContextString(context));

				ConsoleColor color = Console.ForegroundColor;
				Console.ResetColor();
				Console.ForegroundColor = color;
			}

			public static void Cnrf(FunctionContext context){
				if(!OperatingSystem.IsWindows())
					throw new InvalidOperationException("Console opcodes are only supported on Windows"
						+ ExceptionHelper.GetContextString(context));

				ConsoleColor color = Console.BackgroundColor;
				Console.ResetColor();
				Console.BackgroundColor = color;
			}

			public static void Cnwh(FunctionContext context){
				if(!OperatingSystem.IsWindows())
					throw new InvalidOperationException("Console opcodes are only supported on Windows"
						+ ExceptionHelper.GetContextString(context));

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
					throw new InvalidOperationException("Console opcodes are only supported on Windows"
						+ ExceptionHelper.GetContextString(context));

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
					throw new InvalidOperationException("Console opcodes are only supported on Windows"
						+ ExceptionHelper.GetContextString(context));

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
					throw new InvalidOperationException("Console opcodes are only supported on Windows"
						+ ExceptionHelper.GetContextString(context));

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
					throw new InvalidOperationException("Console opcodes are only supported on Windows"
						+ ExceptionHelper.GetContextString(context));

				Console.ResetColor();
			}

			public static void Conw(FunctionContext context){
				if(!OperatingSystem.IsWindows())
					throw new InvalidOperationException("Console opcodes are only supported on Windows"
						+ ExceptionHelper.GetContextString(context));

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
					throw new InvalidOperationException("Console opcodes are only supported on Windows"
						+ ExceptionHelper.GetContextString(context));

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
					throw new InvalidOperationException("Console opcodes are only supported on Windows"
						+ ExceptionHelper.GetContextString(context));

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
					throw new InvalidOperationException("Console opcodes are only supported on Windows"
						+ ExceptionHelper.GetContextString(context));

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

			#region Extended Opcodes - DateTime
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
			#endregion

			public static void Dup(FunctionContext context){
				try{
					Metadata.stack!.Push(Metadata.stack!.Peek());
				}catch(Exception e){
					throw new Exception(e.Message + ExceptionHelper.GetContextString(context));
				}
			}

			public static void Dupd(FunctionContext context){
				object? obj = Metadata.stack!.Peek();

				try{
					Metadata.stack.Push(obj switch{
						Array a => a.Clone(),
						List l => new List(l.ToArray()),
						ArithmeticSet s => new ArithmeticSet(s.ToArray()),
						IChipsStruct i => i.Clone(),
						_ => obj
					});
				}catch(Exception e){
					throw new Exception(e.Message + ExceptionHelper.GetContextString(context));
				}
			}
			#endregion

			#region Functions - E
			public static void Ext(FunctionContext context)
				=> throw new InvalidOperationException("Extended opcodes cannot be called directly");

			public static void Err(FunctionContext context){
				if(context.args[0] is not string msg)
					throw new InvalidOpcodeArgumentException(0, "Value must be a <str> instance", context);

				throw new Exception(msg);
			}

			public static void Exp(FunctionContext context){
				if(ValueConverter.BoxToUnderlyingType(Metadata.Registers.A.Data) is not IFloat a)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not a floating-point number value", context);

				Metadata.Registers.A.Data = (a.Exp() as INumber)!.Value;
				CheckZeroFlag_RegisterA(checkFloats: true);
			}
			#endregion

			#region Functions - F
			public static void Flor(FunctionContext context){
				if(ValueConverter.BoxToUnderlyingType(Metadata.Registers.A.Data) is not IFloat a)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not a floating-point number value", context);

				Metadata.Registers.A.Data = a.Floor().Value;
				CheckZeroFlag_RegisterA(checkFloats: true);
			}
			#endregion

			#region Functions - H
			public static void Halt(FunctionContext context){
				int code;
				if(ValueConverter.AsSignedInteger(Metadata.Registers.X.Data) is long l)
					code = (int)l;
				else if(ValueConverter.AsUnsignedInteger(Metadata.Registers.X.Data) is ulong ul)
					code = (int)ul;
				else
					throw new InvalidOperationException($"Internal Chips Error -- {Metadata.Registers.X} did not contain an integer"
						+ ExceptionHelper.GetContextString(context));

				Environment.Exit(code);
			}
			#endregion

			#region Functions - I
			public static void Idx(FunctionContext context){
				object arg = context.args[0];

				switch(Metadata.Registers.A.Data){
					case string s:
						if(arg is char c)
							Metadata.Registers.X.Data = s.IndexOf(c);
						else if(arg is string s2)
							Metadata.Registers.X.Data = s.IndexOf(s2);
						else
							throw new InvalidOpcodeArgumentException(0, $"A value of type <{TypeTracking.GetChipsType(arg, throwOnNotFound: false)}> cannot be used for operation \"idx\" on a <~str>", context);
						break;
					case List list:
						Metadata.Registers.X.Data = list.IndexOf(arg);
						break;
					case Array arr:
						Metadata.Registers.X.Data = Array.IndexOf(arr, arg);
						break;
					default:
						throw new InvalidRegisterTypeException("The value in " + Metadata.Registers.A.ToString() + " had an invalid type", context);
				}

				CheckZeroFlag_RegisterX();
			}

			public static void Idxv(FunctionContext context){
				if(Metadata.Registers.A.Data is not Indexer idx)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not a <^u32> value", context);

				Metadata.Registers.A.Data = idx.value;

				CheckZeroFlag_RegisterA(checkIntegers: true);
			}

			public static void Inc(FunctionContext context){
				Console.Write(Metadata.Registers.S.Data as string);
				Metadata.Registers.S.Data = Console.ReadKey().KeyChar.ToString();
			}

			public static void Incb(FunctionContext context){
				Console.Write(Metadata.Registers.S.Data as string);
				Metadata.Registers.S.Data = Console.ReadKey(true).KeyChar.ToString();
			}

			public static void Inl(FunctionContext context){
				Console.Write(Metadata.Registers.S.Data as string);
				Metadata.Registers.S.Data = Console.ReadLine();

				CheckZeroFlag_RegisterS();
			}

			public static void Intp(FunctionContext context){
				if(Metadata.Registers.A.Data is not object[] arr)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not a <~arr:obj> value", context);

				Metadata.Registers.S.Data = string.Format((Metadata.Registers.S.Data as string)!, arr);

				CheckZeroFlag_RegisterS();
			}

			public static void Inv(FunctionContext context){
				if(ValueConverter.BoxToUnderlyingType(Metadata.Registers.A.Data) is not IFloat a)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not a floating-point value", context);

				Metadata.Registers.A.Data = (a.Inverse() as INumber)!.Value;
				CheckZeroFlag_RegisterA(checkFloats: true);
			}

			public static void Inx(FunctionContext context){
				Metadata.Registers.X.Data = (Metadata.Registers.X.Data as INumber)!.Increment();

				CheckZeroFlag_RegisterX();
			}

			public static void Iny(FunctionContext context){
				Metadata.Registers.Y.Data = (Metadata.Registers.Y.Data as INumber)!.Increment();

				CheckZeroFlag_RegisterY();
			}

			#region Extended Opcodes - I/O
			public static void Iob(FunctionContext context){
				if(!ValueIsValidForIOStreamHandle(context.args[0], out int handle))
					throw new InvalidOpcodeArgumentException(0, "Value was either not an integer or exceeded the I/O handle ID bounds of [0..7]", context);

				Metadata.ioHandles![handle].Begin(context);
			}

			public static void Ioc(FunctionContext context){
				if(!ValueIsValidForIOStreamHandle(context.args[0], out int handle))
					throw new InvalidOpcodeArgumentException(0, "Value was either not an integer or exceeded the I/O handle ID bounds of [0..7]", context);

				Metadata.ioHandles![handle].Close(context);
			}

			public static void Iofp(FunctionContext context){
				object arg0 = context.args[0];
				object arg1 = context.args[1];
				object arg2 = context.args[2];

				if(!ValueIsValidForIOStreamHandle(arg0, out int handle))
					throw new InvalidOpcodeArgumentException(0, "Value was either not an integer or exceeded the I/O handle ID bounds of [0..7]", context);

				long offset;
				if(ValueConverter.AsSignedInteger(arg1) is long l)
					offset = l;
				else if(ValueConverter.AsUnsignedInteger(arg1) is ulong ul)
					offset = (long)ul;
				else
					throw new InvalidOpcodeArgumentException(1, "Value was not an integer", context);

				SeekOrigin seek;
				if(ValueConverter.AsSignedInteger(arg2) is long l2){
					if(l2 >= (int)SeekOrigin.Begin && l2 <= (int)SeekOrigin.End)
						seek = (SeekOrigin)l2;
					else
						throw new InvalidOpcodeArgumentException(2, "Value exceeded the valid range of SeekOrigin types: [0..2]", context);
				}else if(ValueConverter.AsUnsignedInteger(arg2) is ulong ul2){
					if(ul2 <= (int)SeekOrigin.End)
						seek = (SeekOrigin)ul2;
					else
						throw new InvalidOpcodeArgumentException(2, "Value exceeded the valid range of SeekOrigin types: [0..2]", context);
				}else
					throw new InvalidOpcodeArgumentException(2, "Value was not an integer", context);

				Metadata.ioHandles![handle].Seek(offset, seek, context);
			}

			public static void Ior(FunctionContext context){
				if(!ValueIsValidForIOStreamHandle(context.args[0], out int handle))
					throw new InvalidOpcodeArgumentException(0, "Value was either not an integer or exceeded the I/O handle ID bounds of [0..7]", context);

				if(context.args[1] is not string type)
					throw new InvalidOpcodeArgumentException(1, "Value must be a type reference", context);

				Metadata.Registers.A.Data = Metadata.ioHandles![handle].Read(type, context);

				CheckZeroFlag_RegisterA(checkIntegers: true, checkFloats: true, checkCollections: true, checkStrings: true);
			}

			public static void Ios(FunctionContext context){
				object arg0 = context.args[0];
				object arg1 = context.args[1];

				if(!ValueIsValidForIOStreamHandle(arg0, out int handle))
					throw new InvalidOpcodeArgumentException(0, "Value was either not an integer or exceeded the I/O handle ID bounds of [0..7]", context);

				int setting;
				if(ValueConverter.AsSignedInteger(arg1) is long l)
					setting = (int)l;
				else if(ValueConverter.AsUnsignedInteger(arg1) is ulong ul)
					setting = (int)ul;
				else
					throw new InvalidOpcodeArgumentException(1, "Value was not an integer", context);

				if(setting < IOHandle.SETTING_BINARY || setting > IOHandle.SETTING_MODE)
					throw new InvalidOpcodeArgumentException(1, $"Value exceeded the valid range of I/O setting IDs: [{IOHandle.SETTING_BINARY}..{IOHandle.SETTING_MODE}]", context);

				var io = Metadata.ioHandles![handle];

				if(context.args.Length > 2){
					object arg2 = context.args[2];

					bool ParseBooleanSetting(string setting){
						if(arg2 is bool b)
							return b;
						else if(ValueConverter.AsSignedInteger(arg2) is long l2){
							if(l2 == 0)
								return false;
							else if(l2 == 1)
								return true;
						}else if(ValueConverter.AsUnsignedInteger(arg2) is ulong ul2){
							if(ul2 == 0)
								return false;
							else if(ul2 == 1)
								return true;
						}

						throw new InvalidOpcodeArgumentException(2, $"I/O setting \"{setting}\" must be provided an integer value set to 0 or 1, or a <bool>", context);
					}

					switch(setting){
						case IOHandle.SETTING_BINARY:
							io.BinaryModeActive = ParseBooleanSetting("binary/stream");
							break;
						case IOHandle.SETTING_WRITENEWLINES:
							io.WriteNewlines = ParseBooleanSetting("write newlines");
							break;
						case IOHandle.SETTING_WRITETOFILE:
							io.WriteToStream = ParseBooleanSetting("read/write");
							break;
						case IOHandle.SETTING_FILE:
							if(arg2 is not string file)
								throw new InvalidOpcodeArgumentException(2, "I/O setting \"file\" must be provided a <str> value", context);

							io.file = file;
							break;
						case IOHandle.SETTING_MODE:
							bool success = false;
							FileMode mode = FileMode.CreateNew;
							if(ValueConverter.AsSignedInteger(arg2) is long l2)
								success = Enum.TryParse(l2.ToString(), out mode);
							else if(ValueConverter.AsUnsignedInteger(arg2) is ulong ul2)
								success = Enum.TryParse(ul2.ToString(), out mode);
						
							if(!success)
								throw new InvalidOpcodeArgumentException(2, $"I/O setting \"mode\" must be provided an <integer> value within [{(int)FileMode.CreateNew}..{(int)FileMode.Append}]", context);

							io.mode = mode;
							break;
					}
				}else{
					Metadata.Registers.A.Data = setting switch{
						IOHandle.SETTING_BINARY => io.BinaryModeActive,
						IOHandle.SETTING_WRITENEWLINES => io.WriteNewlines,
						IOHandle.SETTING_WRITETOFILE => io.WriteToStream,
						IOHandle.SETTING_FILE => io.file,
						IOHandle.SETTING_MODE => (int)io.mode!,
						_ => throw new InvalidOperationException("Internal Chips Error -- I/O setting check failed"
							+ ExceptionHelper.GetContextString(context))
					};

					CheckZeroFlag_RegisterA(checkIntegers: true, checkStrings: true);
				}
			}

			public static void Iow(FunctionContext context){
				if(!ValueIsValidForIOStreamHandle(context.args[0], out int handle))
					throw new InvalidOpcodeArgumentException(0, "Value was either not an integer or exceeded the I/O handle ID bounds of [0..7]", context);

				Metadata.ioHandles![handle].Write(context.args[1], context);

				CheckZeroFlag_RegisterA(checkIntegers: true, checkFloats: true, checkCollections: true, checkStrings: true);
			}
			#endregion

			public static void Is(FunctionContext context){
				if(context.args[0] is not string type)
					throw new InvalidOpcodeArgumentException(0, "Value must be a type reference", context);

				if(type == "~arr" && Metadata.Registers.A.Data is Array)
					Metadata.Flags.Comparison = true;
				else if(TypeTracking.GetChipsType(Metadata.Registers.A.Data) == type)
					Metadata.Flags.Comparison = true;
			}

			public static void Isa(FunctionContext context){
				if(context.args[0] is not string type)
					throw new InvalidOpcodeArgumentException(0, "Value must be a type reference", context);

				if(Metadata.Registers.A.Data is Array array && TypeTracking.GetChipsType(array.GetType().GetElementType()!) == type)
					Metadata.Flags.Comparison = true;
			}
			#endregion

			#region Functions - L
			public static void Lda(FunctionContext context)
				=> throw new InvalidOperationException("Lda opcode should not be called directly"
					+ ExceptionHelper.GetContextString(context));

			public static void Ldrg(FunctionContext context){
				Metadata.Registers.A.Data = Metadata.programArgs;

				CheckZeroFlag_RegisterA(checkCollections: true);
			}

			public static void Len(FunctionContext context){
				Metadata.Registers.A.Data = Metadata.Registers.A.Data switch{
					Array arr => arr.Length,
					ArithmeticSet set => set.NumberCount,
					List _ => throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " contained a <~list> instance.  To get the count of a <~list>, use the \"lscp\" instruction instead", context),
					null => throw new ArgumentNullException(Metadata.Registers.A.ToString(), "Value was null"
						+ ExceptionHelper.GetContextString(context)),
					_ => throw new InvalidRegisterTypeException($"Cannot perform operation \"length\" on a <{TypeTracking.GetChipsType(Metadata.Registers.A.Data, throwOnNotFound: false)}> value", context)
				};

				CheckZeroFlag_RegisterA(checkIntegers: true);
			}

			public static void Lens(FunctionContext context){
				if(Metadata.Registers.A.Data is not List list)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not a <~list> instance", context);

				if(ValueConverter.BoxToUnderlyingType(Metadata.Registers.Y.Data) is not IInteger a)
					throw new InvalidRegisterTypeException(Metadata.Registers.Y.ToString() + " was not an integer", context);

				var aNum = (a as INumber)!;
				if(ArithmeticSet.Number.CompareNumbers(aNum.Value, 0) < 0 || ArithmeticSet.Number.CompareNumbers(aNum.Value, int.MaxValue) > 0)
					throw new InvalidOperationException("Value was not valid for List.Capacity"
						+ ExceptionHelper.GetContextString(context));

				int newSize = (int)ValueConverter.CastToInt32_T(aNum).Value;
				list.Capacity = newSize;
			}

			public static void Ln(FunctionContext context){
				if(ValueConverter.BoxToUnderlyingType(Metadata.Registers.A.Data) is not IFloat a)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not a floating-point number value", context);

				Metadata.Registers.A.Data = (a.Ln() as INumber)!.Value;
				CheckZeroFlag_RegisterA(checkFloats: true);
			}

			public static void Log(FunctionContext context){
				if(ValueConverter.BoxToUnderlyingType(Metadata.Registers.A.Data) is not IFloat a)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not a floating-point number value", context);

				Metadata.Registers.A.Data = (a.Log10() as INumber)!.Value;
				CheckZeroFlag_RegisterA(checkFloats: true);
			}

			public static void Lscp(FunctionContext context){
				if(Metadata.Registers.A.Data is not List list)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not a <~list> instance", context);

				Metadata.Registers.A.Data = list.Capacity;

				CheckZeroFlag_RegisterA(checkIntegers: true);
			}

			public static void Lsct(FunctionContext context){
				if(Metadata.Registers.A.Data is not List list)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not a <~list> instance", context);

				Metadata.Registers.A.Data = list.Count;

				CheckZeroFlag_RegisterA(checkIntegers: true);
			}
			#endregion

			#region Functions - M
			public static void Mov(FunctionContext context)
				=> throw new InvalidOperationException("Mov opcode should not be called directly"
					+ ExceptionHelper.GetContextString(context));

			public static void Mul(FunctionContext context){
				if(ValueConverter.BoxToUnderlyingType(Metadata.Registers.A.Data) is not INumber a)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not a number value", context);
				if(ValueConverter.BoxToUnderlyingType(context.args[0]) is not INumber arg)
					throw new InvalidOpcodeArgumentException(0, "Value was not a number value", context);

				Metadata.Registers.A.Data = a.Multiply(arg).Value;
				CheckZeroFlag_RegisterA(checkIntegers: true, checkFloats: true);
			}
			#endregion

			#region Functions - N
			public static void Neg(FunctionContext context){
				if(ValueConverter.BoxToUnderlyingType(Metadata.Registers.A.Data) is not INumber a)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not a number value", context);

				Metadata.Registers.A.Data = a.Negate().Value;
				CheckZeroFlag_RegisterA(checkIntegers: true, checkFloats: true);
			}

			public static void New(FunctionContext context){
				//arg0: type
				//arg1: arr -- if opcode uses it
				if(context.args[0] is not string type)
					throw new InvalidOpcodeArgumentException(0, "Value was not a type reference", context);

				if(context.args.Length > 1){
					switch(type){
						case "~date":
							switch(context.args[1]){
								case long ticks:
									Metadata.stack!.Push(new DateTime(ticks));
									break;
								case int[] values:
									if(values.Length == 3)
										Metadata.stack!.Push(new DateTime(values[0], values[1], values[2]));
									else if(values.Length == 6)
										Metadata.stack!.Push(new DateTime(values[0], values[1], values[2], values[3], values[4], values[5]));
									else if(values.Length == 7)
										Metadata.stack!.Push(new DateTime(values[0], values[1], values[2], values[3], values[4], values[5], values[6]));
									else
										throw new InvalidOpcodeArgumentException(1, "Value (<~arr:i32> instance) had an invalid amount of members for <~date> value creation", context);
									break;
								default:
									throw new InvalidOpcodeArgumentException(1, "Value was not an <i64> or <~arr:i32>", context);
							}
							break;
						case "~rand":
							if(ValueConverter.BoxToUnderlyingType(context.args[1]) is not IInteger seed)
								throw new InvalidOpcodeArgumentException(1, "Value was not an integer", context);

							Metadata.stack!.Push(new Random((int)ValueConverter.CastToInt32_T((seed as INumber)!).Value));
							break;
						case "~set":
							if(context.args[1] is not Array array)
								throw new InvalidOpcodeArgumentException(1, "Value was not an array", context);

							Metadata.stack!.Push(new ArithmeticSet(array));
							break;
						case "~time":
							switch(context.args[1]){
								case long ticks:
									Metadata.stack!.Push(new TimeSpan(ticks));
									break;
								case int[] values:
									if(values.Length == 3)
										Metadata.stack!.Push(new TimeSpan(values[0], values[1], values[2]));
									else if(values.Length == 4)
										Metadata.stack!.Push(new TimeSpan(values[0], values[1], values[2], values[3]));
									else if(values.Length == 5)
										Metadata.stack!.Push(new TimeSpan(values[0], values[1], values[2], values[3], values[4]));
									else
										throw new InvalidOpcodeArgumentException(1, "Value (<~arr:i32> instance) had an invalid amount of members for <~time> value creation", context);
									break;
								default:
									throw new InvalidOpcodeArgumentException(1, "Value was not an <i64> or <~arr:i32>", context);
							}
							break;
						default:
							throw new InvalidOpcodeArgumentException(0, "Could not determine type/function from argument", context);
					}
				}else{
					//Type only
					switch(type){
						case "^u32":
							if(ValueConverter.BoxToUnderlyingType(Metadata.Registers.X.Data) is not IInteger value)
								throw new InvalidRegisterTypeException(Metadata.Registers.X.ToString() + " was not an integer", context);

							Metadata.stack!.Push(new Indexer((int)ValueConverter.CastToInt32_T((value as INumber)!).Value));
							break;
						case "~date":
							Metadata.stack!.Push(DateTime.MinValue);
							break;
						case "~list":
							if(ValueConverter.BoxToUnderlyingType(Metadata.Registers.Y.Data) is not IInteger capacity)
								throw new InvalidRegisterTypeException(Metadata.Registers.Y.ToString() + " was not an integer", context);

							Metadata.stack!.Push(new List((int)ValueConverter.CastToInt32_T((capacity as INumber)!).Value));
							break;
						case "~rand":
							Metadata.stack!.Push(new Random());
							break;
						case "~range":
							if(ValueConverter.BoxToUnderlyingType(Metadata.Registers.X.Data) is not IInteger start)
								throw new InvalidRegisterTypeException(Metadata.Registers.X.ToString() + " was not an integer", context);
							if(ValueConverter.BoxToUnderlyingType(Metadata.Registers.Y.Data) is not IInteger end)
								throw new InvalidRegisterTypeException(Metadata.Registers.Y.ToString() + " was not an integer", context);

							Metadata.stack!.Push(new Types.Range((int)ValueConverter.CastToInt32_T((start as INumber)!).Value, (int)ValueConverter.CastToInt32_T((end as INumber)!).Value));
							break;
						case "~regex":
							if(Metadata.Registers.S.Data is not string pattern)
								throw new InvalidRegisterTypeException(Metadata.Registers.S.ToString() + " was not a <str> instance", context);

							Metadata.stack!.Push(new Types.Regex(pattern));
							break;
						case "~set":
							Metadata.stack!.Push(ArithmeticSet.EmptySet);
							break;
						case "~time":
							Metadata.stack!.Push(TimeSpan.Zero);
							break;
						case string a when a.StartsWith("~arr:"):
							if(ValueConverter.BoxToUnderlyingType(Metadata.Registers.X.Data) is not IInteger length)
								throw new InvalidRegisterTypeException(Metadata.Registers.X.ToString() + " was not an integer", context);

							string subType = a[5..];
							Metadata.stack!.Push(Array.CreateInstance(TypeTracking.GetCSharpType(subType) ?? throw new InvalidOpcodeArgumentException(0, "Type cannot be used as an array element type: " + subType, context), (int)ValueConverter.CastToInt32_T((length as INumber)!).Value));
							break;
						case string s when s.StartsWith("~ud:"):
							//Determine the type to use and call its requested constructor
							string ss = s[4..];

							string[] split = ss.Split("->");
							if(split.Length != 2)
								throw new InvalidOpcodeArgumentException(0, "Could not determine type and constructor from argument", context);

							if(!Metadata.userDefinedTypes.TryGetValue(split[0], out Type? udType))
								throw new InvalidOpcodeArgumentException(0, $"Could not find type \"{split[1]}\"", context);

							if(!split[1].StartsWith(".ctor"))
								throw new InvalidOpcodeArgumentException(0, "Function provided was not a constructor", context);

							ConstructorInfo ctor = ReflectionHelper.GetConstructor(s, udType, Type.EmptyTypes);

							Metadata.stack!.Push(ctor.Invoke(null));
							break;
						default:
							throw new InvalidOpcodeArgumentException(0, "Could not determine type/function from argument", context);
					}
				}
			}

			public static void Not(FunctionContext context){
				if(ValueConverter.BoxToUnderlyingType(Metadata.Registers.A.Data) is not IInteger a)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not an integer value", context);

				Metadata.Registers.A.Data = (a.Not() as INumber)!.Value;
				CheckZeroFlag_RegisterA(checkIntegers: true);
			}
			#endregion
		}
	}
}
