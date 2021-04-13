using System.Windows.Forms;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Api;
using StarWing.Framework.Input;


namespace Tests.StarWing.Framework.Input.Tests
{
    [TestFixture]
    public class KeyboardTests
    {
        private FakeKeyboardManipulator _keyboardManipulator;
        private Keyboard _keyboard;


        public KeyboardTests()
        {
            _keyboardManipulator = new FakeKeyboardManipulator();
        }

        [SetUp]
        public void SetUp()
        {
            _keyboard = new Keyboard(_keyboardManipulator);
        }

        [TearDown]
        public void TearDown()
        {
            _keyboardManipulator.ReleaseAll();
            _keyboard = null;
        }

        [TestCase(Keys.A)]
        [TestCase(Keys.W)]
        [TestCase(Keys.Up)]
        [TestCase(Keys.Escape)]
        [TestCase(Keys.S)]
        [TestCase(Keys.Y)]
        [TestCase(Keys.Down)]
        [TestCase(Keys.Tab)]
        [TestCase(Keys.F1)]
        [TestCase(Keys.VolumeDown)]
        [TestCase(Keys.ShiftKey)]

        public void CanRegisterInput_UsualKeys(Keys key)
        {
            _keyboardManipulator.Press(key);
            var isKeyDown = _keyboard.Status.IsKeyDown(key);
            Assert.IsTrue(isKeyDown);
        }

        [TestCase(Keys.Alt)]
        [TestCase(Keys.Shift)]
        [TestCase(Keys.Control)]
        public void CanRegisterInput_ModifierKeys(Keys key)
        {
            _keyboardManipulator.Press(key);
            var isKeyDown = _keyboard.Status.IsKeyDown(key);
            Assert.IsTrue(isKeyDown);
        }

        [TestCase(Keys.A)]
        [TestCase(Keys.B)]
        [TestCase(Keys.ControlKey)]
        public void CanRegisterJustPressedKeys(Keys key)
        {
            _keyboardManipulator.Press(key);
            var isKeyJustPressed = _keyboard.Status.IsKeyDown(key);
            Assert.IsTrue(isKeyJustPressed);
        }
    }
}