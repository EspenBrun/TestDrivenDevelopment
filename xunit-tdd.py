class TestResult:
    def __init__(self):
        self.runCount = 0

    def testStarted(self):
        self.runCount = self.runCount + 1

    def summary(self):
        return "%d run, 0 failed" % self.runCount


class TestCase:
    def __init__(self, name):
        self.name = name

    def setUp(self):
        pass

    def run(self):
        result = TestResult()
        result.testStarted()
        self.setUp()
        # This code will attr/method with name 'name'
        # Fails if we do not have anything named 'name'
        method = getattr(self, self.name)
        method()
        self.tearDown()
        return result

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

    def testBrokenMethod(self):
        raise Exception


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

    def testResult(self):
        test = WasRun("testMethod")
        result = test.run()
        print(result.summary())
        assert ("1 run, 0 failed" == result.summary())

    def testFailedResult(self):
        test = WasRun("testBrokenMethod")
        result = test.run()
        assert ("1 run, 1 failed" == result.summary())


TestCaseTest("testTemplateMethod").run()
TestCaseTest("testResult").run()
TestCaseTest("testFailedResult").run()
