using System;
using System.Numerics;

namespace COSIG_RayTracing_Parser__ConsoleApp_.Objects
{
    internal class Transformation
    {
        // Translation
        public Vector3 Translation { get; set; }

        public void SetTranslation(float x, float y, float z)
        {
            Translation = new Vector3(x, y, z);
        }

        // Rotation
        public double Rotation_x { get; set; }
        public double Rotation_y { get; set; }
        public double Rotation_z { get; set; }

        // Scale
        public Vector3 Scale { get; set; }

        public void SetScale(float x, float y, float z)
        {
            Scale = new Vector3(x, y, z);
        }

        public Matrix4x4 TransformationMatrix { get; set; }


        public Matrix4x4 InvertedTransformationMatrix { get; set; }

        public Matrix4x4 TransposedInvertedTransformationMatrix { get; set; }

        public Transformation()
        {
            Translation = new Vector3();

            Rotation_x = 0;
            Rotation_y = 0;
            Rotation_z = 0;

            Scale = new Vector3(1, 1, 1);
            TransformationMatrix = new Matrix4x4(
                1, 0, 0, 0,
                0, 1, 0, 0,
                0, 0, 1, 0,
                0, 0, 0, 1
                );
        }

        public void CalculateTransformationMatrix(Matrix4x4 cameraTransformationMatrix)
        {
            TransformationMatrix = new Matrix4x4(
                1, 0, 0, 0,
                0, 1, 0, 0,
                0, 0, 1, 0,
                0, 0, 0, 1
                );
            Translate();
            RotateX();
            RotateY();
            RotateZ();
            ScaleFunc();

            TransformationMatrix = cameraTransformationMatrix * TransformationMatrix;

            Matrix4x4.Invert(TransformationMatrix, out Matrix4x4 aux);
            InvertedTransformationMatrix = aux;

            TransposedInvertedTransformationMatrix = Matrix4x4.Transpose(aux);
        }

        public static Vector4 TransformVector4(Matrix4x4 transformationMatrix, Vector4 vector)
        {
            /*
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    result[i] += TransformationMatrix[i, j] * pointA[j];
            */
            return new Vector4(
                transformationMatrix.M11 * vector.X + transformationMatrix.M12 * vector.Y + transformationMatrix.M13 * vector.Z + transformationMatrix.M14 * vector.W,
                transformationMatrix.M21 * vector.X + transformationMatrix.M22 * vector.Y + transformationMatrix.M23 * vector.Z + transformationMatrix.M24 * vector.W,
                transformationMatrix.M31 * vector.X + transformationMatrix.M32 * vector.Y + transformationMatrix.M33 * vector.Z + transformationMatrix.M34 * vector.W,
                transformationMatrix.M41 * vector.X + transformationMatrix.M42 * vector.Y + transformationMatrix.M43 * vector.Z + transformationMatrix.M44 * vector.W);
        }

        private void Translate()
        {
            Matrix4x4 translateMatrix = new Matrix4x4(
                1, 0, 0, Translation.X,
                0, 1, 0, Translation.Y,
                0, 0, 1, Translation.Z,
                0, 0, 0, 1
                );

            TransformationMatrix *= translateMatrix;
        }

        private void RotateX()
        {
            double angle = Rotation_x * Math.PI / 180.0;
            float a_sin = (float)Math.Sin(angle);
            float a_cos = (float)Math.Cos(angle);
            Matrix4x4 rotateMatrix = new Matrix4x4(
                1, 0, 0, 0,
                0, a_cos, -a_sin, 0,
                0, a_sin, a_cos, 0,
                0, 0, 0, 1
                );

            TransformationMatrix *= rotateMatrix;
        }

        private void RotateY()
        {
            double angle = Rotation_y * Math.PI / 180.0;
            float a_sin = (float)Math.Sin(angle);
            float a_cos = (float)Math.Cos(angle);
            Matrix4x4 rotateMatrix = new Matrix4x4(
                a_cos, 0, a_sin, 0,
                0, 1, 0, 0,
                -a_sin, 0, a_cos, 0,
                0, 0, 0, 1
                );

            TransformationMatrix *= rotateMatrix;
        }

        private void RotateZ()
        {
            double angle = Rotation_z * Math.PI / 180.0;
            float a_sin = (float)Math.Sin(angle);
            float a_cos = (float)Math.Cos(angle);
            Matrix4x4 rotateMatrix = new Matrix4x4(
                a_cos, -a_sin, 0, 0,
                a_sin, a_cos, 0, 0,
                0, 0, 1, 0,
                0, 0, 0, 1
                );

            TransformationMatrix *= rotateMatrix;
        }

        private void ScaleFunc()
        {
            Matrix4x4 scaleMatrix = new Matrix4x4(
                Scale.X, 0, 0, 0,
                0, Scale.Y, 0, 0,
                0, 0, Scale.Z, 0,
                0, 0, 0, 1
                );

            TransformationMatrix *= scaleMatrix;
        }
    }
}
