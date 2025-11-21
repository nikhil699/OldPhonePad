using OldPhonePad.Core;
using Xunit;

namespace OldPhonePad.Tests
{
    public class OldPhonePadConverterTests
    {
        [Theory]
        [InlineData("33#", "E")]
        [InlineData("227*#", "B")]
        [InlineData("4433555 555666#", "HELLO")]
        [InlineData("8 88777444666*664#", "TURING")] // hidden example from prompt
        public void ShouldHandleGivenExamples(string input, string expected)
        {
            var actual = OldPhonePadConverter.OldPhonePad(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("#", "")]
        [InlineData("2#", "A")]
        [InlineData("2222#", "A")]     // cycles through ABC -> back to A
        [InlineData("0#", " ")]       // 0 treated as space
        [InlineData("22*#", "")]      // backspace removes committed char
        [InlineData("2*2#", "A")]     // cancel first sequence, then type A
        public void ShouldHandleEdgeCases(string input, string expected)
        {
            var actual = OldPhonePadConverter.OldPhonePad(input);

            Assert.Equal(expected, actual);
        }
    }
}
