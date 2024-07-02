namespace ModelModule
{
    public class MeshGradientSettingsEventArgs
    {
        public double layerThickness;
        public double surfaceMeshSize;
        public double coreMeshSize;
        public double gradientMeshPower;

        public MeshGradientSettingsEventArgs(double layerThickness, double surfaceMeshSize, double coreMeshSize, double gradientMeshPower)
        {
            this.layerThickness = layerThickness;
            this.surfaceMeshSize = surfaceMeshSize;
            this.coreMeshSize = coreMeshSize;
            this.gradientMeshPower = gradientMeshPower;
        }
    }
}