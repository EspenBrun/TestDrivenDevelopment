class TestCase:
    def __init__(self, name):
        self.name = name

    def setUp(self):
        pass

    def run(self):
        self.setUp()
        # This code will attr/method with name 'name'
        # Fails if we do not have anything named 'name'
        method = getattr(self, self.name)
        method()
        self.tearDown()

    def tearDown(self):
        pass


class WasRun(TestCase):
    """This is the docstring"""

    def __init__(self, name):
        TestCase.__init__(self, name)
        self.log = "setUp"

    def setUp(self):
        pass

    def testMethod(self):
        self.log = self.log + " testMethod"

    def tearDown(self):
        self.log = self.log + " tearDown"


# TestCaseTest inherits TestCase, so it will have run()
# Run is the method that dynamically invokes a method
# with the same name as is given in the `name` parameter in the constructor
# So the method with name "testRunning" is called
# testRunning() is a method that does what we manually tested earlier:
# creates a WasRun, which also inherits TestCase and the run() method,
# executes run, which dynamically invokes the method with same name as given in `name` param in constructor
# which is testMethod(), which sets the flag to 1.
# So: We now have an actual test of what we earlier visually verified

class TestCaseTest(TestCase):
    def testTemplateMethod(self):
        test = WasRun("testMethod")
        test.run()
        assert ("setUp testMethod tearDown" == test.log)


TestCaseTest("testTemplateMethod").run()
