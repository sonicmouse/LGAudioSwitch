using System.Collections.Generic;

namespace LGAudioSwitch.Models
{
	/// <summary>
	/// The <see cref="AudioDevice"/> implementation
	/// </summary>
	public class AudioDevice : IEqualityComparer<AudioDevice>
	{
		/// <summary>
		/// The ID of this <see cref="AudioDevice"/>
		/// </summary>
		public string Id { get; set; }

		/// <summary>
		/// The friendly name of this <see cref="AudioDevice"/>
		/// </summary>
		public string FriendlyName { get; set; }

		/// <summary>
		/// The description of this <see cref="AudioDevice"/>
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// The type of <see cref="AudioDevice"/>
		/// </summary>
		public AudioDeviceType AudioDeviceType { get; set; }

		/// <summary>
		/// Determines whether two instances and another specified <see cref="AudioDevice"/> object have
		/// the same value.
		/// </summary>
		/// <param name="x">The <see cref="AudioDevice"/> to compare from</param>
		/// <param name="y">The <see cref="AudioDevice"/> to compare to</param>
		/// <returns>true if they are equal, else false</returns>
		public bool Equals(AudioDevice x, AudioDevice y) =>
			x.Id.Equals(y.Id);

		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="obj">The object to compare</param>
		/// <returns>true if they are equal, else false</returns>
		public override bool Equals(object obj)
		{
			if(ReferenceEquals(this, obj)) { return true; }
			if((obj is AudioDevice dev) && (dev != null))
			{
				return Equals(this, dev);
			}
			return false;
		}

		/// <summary>
		/// Returns the hash code for an object
		/// </summary>
		/// <param name="obj">The object to hash</param>
		/// <returns>Hash code</returns>
		public int GetHashCode(AudioDevice obj) =>
			obj.GetHashCode();

		/// <summary>
		/// Returns the hash code for this object
		/// </summary>
		/// <returns>Hash code</returns>
		public override int GetHashCode() =>
			Id.GetHashCode();

		/// <summary>
		/// A string that represents the current object
		/// </summary>
		public override string ToString() =>
			FriendlyName;
	}
}
