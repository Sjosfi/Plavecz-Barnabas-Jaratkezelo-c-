using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using JaratKezeloProject;

namespace TestJaratKezeloProject
{
    public class JaratKezeloTests
    {
        [Fact]
        public void UjJarat_ShouldAddJarat()
        {
            var jaratKezelo = new JaratKezelo();
            jaratKezelo.ujJarat("J123", "BUD", "JFK", new DateTime(2024, 6, 1, 8, 0, 0));

            var result = jaratKezelo.mikorIndul("J123");

            Assert.Equal(new DateTime(2024, 6, 1, 8, 0, 0), result);
        }

        [Fact]
        public void UjJarat_DuplicateJaratSzam_ShouldThrowException()
        {
            var jaratKezelo = new JaratKezelo();
            jaratKezelo.ujJarat("J123", "BUD", "JFK", new DateTime(2024, 6, 1, 8, 0, 0));

            Assert.Throws<ArgumentException>(() =>
                jaratKezelo.ujJarat("J123", "BUD", "LAX", new DateTime(2024, 6, 1, 9, 0, 0))
            );
        }

        [Fact]
        public void Keses_ShouldAddDelay()
        {
            var jaratKezelo = new JaratKezelo();
            jaratKezelo.ujJarat("J123", "BUD", "JFK", new DateTime(2024, 6, 1, 8, 0, 0));
            jaratKezelo.keses("J123", 30);

            var result = jaratKezelo.mikorIndul("J123");

            Assert.Equal(new DateTime(2024, 6, 1, 8, 30, 0), result);
        }

        [Fact]
        public void Keses_NegativeDelay_ShouldThrowException()
        {
            var jaratKezelo = new JaratKezelo();
            jaratKezelo.ujJarat("J123", "BUD", "JFK", new DateTime(2024, 6, 1, 8, 0, 0));
            jaratKezelo.keses("J123", 30);

            Assert.Throws<Exception>(() => jaratKezelo.keses("J123", -40));
        }

        [Fact]
        public void JaratokRepuloterrol_ShouldReturnCorrectJaratSzam()
        {
            var jaratKezelo = new JaratKezelo();
            jaratKezelo.ujJarat("J123", "BUD", "JFK", new DateTime(2024, 6, 1, 8, 0, 0));
            jaratKezelo.ujJarat("J124", "BUD", "LAX", new DateTime(2024, 6, 1, 9, 0, 0));
            jaratKezelo.ujJarat("J125", "LHR", "JFK", new DateTime(2024, 6, 1, 10, 0, 0));

            var result = jaratKezelo.jaratokRepuloterrol("BUD");

            Assert.Contains("J123", result);
            Assert.Contains("J124", result);
            Assert.DoesNotContain("J125", result);
        }
    }
}