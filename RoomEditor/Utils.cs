namespace HomeEditor {
    /// <summary>
    /// Random functions without a specific location.
    /// </summary>
    public static class Utils {
        /// <summary>
        /// Clamp <paramref name="x"/> between <paramref name="min"/> and <paramref name="max"/>.
        /// </summary>
        public static int Clamp(int x, int min, int max) => x > 0 ? (x < max ? x : max) : min;

        /// <summary>
        /// Check if two elements have an intersection.
        /// </summary>
        /// <param name="Container">First element</param>
        /// <param name="Content">Second element</param>
        public static bool Intersect(SerializablePanel Container, SerializablePanel Content) {
            // They intersect, if the second rectangle is not entirely left/right/up/down from the first
            return !(Container.Left >= Content.Right || Container.Top >= Content.Bottom ||
                     Container.Right <= Content.Left || Container.Bottom <= Content.Top);
        }
    }
}