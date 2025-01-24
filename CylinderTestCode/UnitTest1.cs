using CylinderProject.Models;

namespace CylinderTestCode
{
    public class UnitTest1
    {
        //1
        [Theory]
        [InlineData(10,20)]
        [InlineData(30,30)]
        [InlineData(20.5,10)]
        public void Are_Radius_And_Height_Correct(double radius,double height)
        {
            Cylinder testobject = new(radius,height);
            Assert.Equal(radius, testobject.Radius);
            Assert.Equal(height, testobject.Height);
        }

        //2
        [Theory]
        [InlineData(-10,20)]
        [InlineData(3.4234,-30)]
        [InlineData(-1,0)]
        public void Are_Radius_And_Height_Not_Negative(double radius,double height) 
        {
            Cylinder testobject;
            Assert.Throws<ArgumentException>(() => testobject = new(radius, height));
        }

        //3
        [Fact]
        public void Are_GetVolume_And_GetSurface_Correct()
        {
            Cylinder cylinder = new(20,20);

            var wanted_volume =Math.PI * Math.Pow(20, 2) * 20;
            var wanted_surface =  2 * Math.PI * Math.Pow(20, 2) + 2 * Math.PI * 20 * 20;
            Assert.Equal(Math.Round(wanted_surface), Math.Round(cylinder.GetSurfaceArea()));
            Assert.Equal(Math.Round(wanted_volume), Math.Round(cylinder.GetVolume()));
        
            

        }

        //4
        [Theory]
        [InlineData(10, 20)]
        [InlineData(32, 30)]
        [InlineData(20.5, 10)]
        public void Does_Resize_Works_And_Intended(double newradius, double newheight)
        {
            const double RADIUS=10, HEIGHT = 10;
          
            Cylinder cylinder = new(RADIUS, HEIGHT);
            cylinder.Resize(newradius, newheight);
            Assert.Equal(newradius, cylinder.Radius);
            Assert.Equal(newheight, cylinder.Height);

        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(-32, 30)]
        [InlineData(20.5, -10)]
        public void Does_Resize_Throwsexeption(double newradius, double newheight)
        {
            const double RADIUS = 10, HEIGHT = 10;

            Cylinder cylinder = new(RADIUS, HEIGHT);
           
            Assert.Throws<ArgumentException>(() => cylinder.Resize(newradius, newheight));
           
        }
        [Theory]
        [InlineData(10, 20)]
        [InlineData(32, 30)]
        public void Is_The_Cylinder_Null(double radius, double height)
        {
            Cylinder cylinder = new(radius,height);

            Assert.NotNull(cylinder);

        }
        [Theory]
        [InlineData(10, 20)]
        [InlineData(32, 30)]
        public void Is_The_Cylinder_In_Range(double radius, double height)
        {
            Cylinder cylinder = new(radius, height);

            Assert.InRange(radius,1,100);
            Assert.InRange(height,1,100);

        }

    }

}