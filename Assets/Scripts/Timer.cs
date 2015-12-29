using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public class Timer
    {
        //todo : BEN_REV : startTime peut-être ?
        private DateTime birth;
        private TimeSpan time;
        //todo : BEN_REV : Dupicata de données. Tu peut le déterminer avec les autres variables.
        private bool end = true;

        /// <summary>
        /// Starts the specified time.
        /// </summary>
        /// <param name="time">The time.</param>
        public void Start(TimeSpan time)
        {
            this.time = time;
            birth = DateTime.Now;
            end = false;
        }

        /// <summary>
        /// Determines whether [is time finished].
        /// </summary>
        /// <returns>boolean if time is finished</returns>
        public bool IsTimeFinished()
        {
            if (!end && birth + time < DateTime.Now)
            {
                end = true;
                return true;
            }
            return false;
        }

        public bool IsStarted()
        {
            return !end;
        }
    }
}
