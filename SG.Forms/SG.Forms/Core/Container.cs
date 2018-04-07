using System;
using System.Collections.Generic;
using System.Text;

namespace SG.Forms
{
    public static partial class Container
    {
        public static ITrack Track;
        public static ISGApp SGApp;

        static Container()
        {
            Container.Track = new CoreTrack();
        }


    }
}
