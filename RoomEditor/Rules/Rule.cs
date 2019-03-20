using System;

namespace HomeEditor.Rules {
    class Rule {
        /// <summary>
        /// Room to check. If null, all sensors will be checked independently.
        /// </summary>
        public Room targetRoom;

        /// <summary>
        /// Field in <see cref="SensorData"/> to check.
        /// </summary>
        public string targetField;

        /// <summary>
        /// Maximum detection interval.
        /// </summary>
        public TimeSpan span;

        /// <summary>
        /// Triggers if the rule happend more than this times in the interval set in <see cref="span"/>.
        /// </summary>
        public int occurence;

        /// <summary>
        /// Triggers if <see cref="targetField"/>'s value falls below this.
        /// </summary>
        public float minValue;

        /// <summary>
        /// Triggers if <see cref="targetField"/>'s value falls over this.
        /// </summary>
        public float maxValue;

        /// <summary>
        /// Check the history entries of the <see cref="targetRoom"/> for this rule.
        /// </summary>
        public void Tick() {
            // TODO
        }
    }
}