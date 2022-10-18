using System;
using System.Collections.Generic;

namespace BadAppleTools.Library.Frame
{
    public class FrameData
    {
        public readonly Orientations Orientation;

        private readonly List<FrameSection> _frameSections;

        private int sectionIndex = 0;

        public FrameData(Orientations orientation, List<FrameSection> frameSections)
        {
            Orientation = orientation;
            _frameSections = frameSections;
        }

        public bool TryGetNextSection(out FrameSection? frameSection)
        {
            if (++sectionIndex < _frameSections.Count)
            {
                frameSection = _frameSections[sectionIndex - 1];
                return true;
            }
            frameSection = null;
            return false;
        }
    }
}
