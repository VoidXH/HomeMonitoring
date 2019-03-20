using System;
using System.Windows.Forms;

namespace HomeEditor {
    /// <summary>
    /// Obstacle editor behaviour.
    /// </summary>
    public partial class HomeEditor : Form {
        /// <summary>
        /// Add a new obstacle.
        /// </summary>
        void AddObstacle_Click(object sender, EventArgs e) => SelectObject(new Obstacle(drawingPanel));

        /// <summary>
        /// Change the selected obstacle's name.
        /// </summary>
        void ObstacleName_TextChanged(object sender, EventArgs e) => ((Obstacle)selection).SetName(((TextBox)sender).Text);
    }
}