using System;
namespace Yandex.Geocoder.Models
{
    public class BoundedByType
    {
        public BoundedByType()
        {
            Envelope = new EnvelopeType();
        }

        public EnvelopeType Envelope { get; set; }
    }
}