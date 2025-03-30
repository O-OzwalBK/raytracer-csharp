namespace Raytracer
{
    class Vector3
    {
        public double[] coordinate = new double[3];

        public Vector3()
        {
            coordinate[0] = 0;
            coordinate[1] = 0;
            coordinate[2] = 0;

            // vector[0] = vector[1] = vector[2] = 0;
        }

        public Vector3(double x, double y, double z)
        {
            coordinate = [x, y, z];
        }

        public double X => coordinate[0];
        public double Y => coordinate[1];
        public double Z => coordinate[2];

        // Indexer for accessing elements by index
        public double this[int i] => coordinate[i];
        public double this[int i]
        {
            get { return coordinate[i]; }
            set { coordinate[i] = value; }
        }

        // flip direction of the vector
        public static Vector3 operator -(Vector3 vector)
        {
            return new Vector3(-vector.coordinate[0], -vector.coordinate[1], -vector.coordinate[2]);
        }

        // Addition assignment operator
        public static Vector3 operator +=(Vector3 vector1, Vector3 vector2)
        {
            coordinate[0] += vector2.coordinate[0];
            coordinate[1] += vector2.coordinate[1];
            coordinate[2] += vector2.coordinate[2];
            return this;
        }

        // Scalar multiplication assignment operator
        public static Vector3 operator *=(Vector3 vector, double multiplier)
        {
            vector.coordinate[0] *= multiplier;
            vector.coordinate[1] *= multiplier;
            vector.coordinate[2] *= multiplier;
            return vector;
        }

        // Scalar division assignment operator
        public static Vector3 operator /=(Vector3 vector, double divisor)
        {
            return vector *= 1 / divisor;
        }

        // Method to calculate length (magnitude) of the vector
        public double Magnitude()
        {
            return Math.Sqrt(LengthSquared());
        }

        // Dot Product
        public static double DotProduct(Vector3 vector1, Vector3 vector2)
        {
            return vector1.coordinate[0] * vector2.coordinate[0] + vector1.coordinate[1] * vector2.coordinate[1] + vector1.coordinate[2] * vector2.coordinate[2];
        }

        // Cross Product
        public static Vector3 CrossProduct(Vector3 vector1, Vector3 vector2)
        {
            return Vector3(
                vector1.coordinate[1] * vector2.coordinate[2] - vector1.coordinate[2] * vector2.coordinate[1],
                vector1.coordinate[2] * vector2.coordinate[0] - vector1.coordinate[0] * vector2.coordinate[2],
                vector1.coordinate[0] * vector2.coordinate[1] - vector1.coordinate[1] * vector2.coordinate[0]
            )
        }

        public static Vector3 UnitVector()
        {
            // pass the maginitude of the vector to the divisior
        }
    }
}