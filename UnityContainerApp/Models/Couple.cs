using System;

namespace UnityContainerApp.Models
{
    public sealed class Couple
    {
        public Girlfriend Girlfriend { get; }

        public Boyfriend Boyfriend { get; } = new Boyfriend();

        public Couple(Girlfriend girlfriend)
        {
            this.Girlfriend = girlfriend;
        }

        public override string ToString() => $"{this.Boyfriend.Name}と{this.Girlfriend.Name}はカップルです。";
    }
}