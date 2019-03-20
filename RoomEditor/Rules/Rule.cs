﻿using System;
using System.Collections.Generic;

namespace HomeEditor.Rules {
    public class Rule {
        /// <summary>
        /// Name of this rule.
        /// </summary>
        public string name;

        /// <summary>
        /// Room to check. If null, all sensors will be checked independently.
        /// </summary>
        public Room targetRoom;

        /// <summary>
        /// Property in <see cref="SensorData"/> to check.
        /// </summary>
        public string targetProperty;

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
            List<SensorData> source = new List<SensorData>();
            // TODO: collect from target room or all sensors
            source.Sort((a, b) => a.Timestamp.CompareTo(b.Timestamp));
        }
    }
}