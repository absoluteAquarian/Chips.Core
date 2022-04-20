using Chips.Core.Meta;

namespace Chips.Core.Types.UserDefined {
	/// <summary>
	/// An interface from which all user-defined Chips structs inherit from
	/// </summary>
	public interface IChipsStruct {
		/// <summary>
		/// Used to make a duplicate of the object.
		/// If not defined by the user, simply returns <seealso cref="object.MemberwiseClone"/>.
		/// </summary>
		object Clone();

		/// <summary>
		/// Used when serializing the object to an I/O stream.
		/// If not defined by the user, nothing happens.
		/// Must be defined if <seealso cref="FromByteArray(byte[])"/> is defined.
		/// </summary>
		byte[] ToByteArray();

		/// <summary>
		/// Used when deserializing the object from an I/O stream.
		/// If not defined by the user, nothing happens.
		/// Must be defined if <seealso cref="ToByteArray"/> is defined.
		/// </summary>
		void FromByteArray(byte[] bytes);

		/// <summary>
		/// Used for the "<c>prse</c>" instruction.
		/// Must be defined by the user.
		/// <para>
		/// The string to parse is located in <seealso cref="Metadata.Registers.S"/> (<c>&amp;S</c>).
		/// For indicating a successful parse, use the "<c>stn</c>" instruction to set <seealso cref="Metadata.Flags.Conversion"/> (<c>$N</c>) to <see langword="true"/>.
		/// </para>
		/// <para>
		/// If the parse was successful, the parsed value should be moved into <seealso cref="Metadata.Registers.A"/> (<c>&amp;A</c>) via "<c>mov</c>".
		/// </para>
		/// </summary>
		void TryParse();
	}
}
