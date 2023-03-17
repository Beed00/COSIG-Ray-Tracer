using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

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
        }

        public Vector4 TransformVector4(Vector4 vector, bool invertTransformation)
        {
            /*
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    result[i] += TransformationMatrix[i, j] * pointA[j];
            */
            Matrix4x4 usedTransformation = invertTransformation ? InvertedTransformationMatrix: TransformationMatrix;
            return new Vector4(
                usedTransformation.M11 * vector.X + usedTransformation.M12 * vector.Y + usedTransformation.M13 * vector.Z + usedTransformation.M14 * vector.W,
                usedTransformation.M21 * vector.X + usedTransformation.M22 * vector.Y + usedTransformation.M23 * vector.Z + usedTransformation.M24 * vector.W,
                usedTransformation.M31 * vector.X + usedTransformation.M32 * vector.Y + usedTransformation.M33 * vector.Z + usedTransformation.M34 * vector.W,
                usedTransformation.M41 * vector.X + usedTransformation.M42 * vector.Y + usedTransformation.M43 * vector.Z + usedTransformation.M44 * vector.W);
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
