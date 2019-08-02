using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorsView.Utility
{
    public class Counter
    {
        private int _threshold;
        private int _total;

        public event EventHandler ThresholdReached;

        public Counter(int passedThreshold)
        {
            _total = 0;
            _threshold = passedThreshold;
        }

        public void CountUp()
        {
            _total++;
            if(_total >= _threshold)
            {
                OnThresholdReached(EventArgs.Empty);
            }
        }

        protected virtual void OnThresholdReached(EventArgs e)
        {
            EventHandler handler = ThresholdReached;
            if(handler != null)
            {
                handler(this, e);
            }
        }
    }
}
