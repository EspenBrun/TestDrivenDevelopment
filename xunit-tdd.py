class TestResult:
    def __init__(self):
        self.runCount = 0
        self.errorCount = 0
        self.errorNames = []

    def testStarted(self):
        self.runCount = self.runCount + 1

    def summary(self):
        return "%d run, %d failed" % (self.runCount, self.errorCount)

    def testFailed(self, name):
        self.errorNames.append(name)
        self.errorCount += 1

    def failedTests(self):
        return self.failedTests


class TestCase:
    def __init__(self, name):
        self.name = name

    def setUp(self):
        pass

    def run(self, result):
        result.testStarted()
        self.setUp()
        # This code will attr/method with name 'name'
        # Fails if we do not have anything named 'name'
        try:
            method = getattr(self, self.name)
            method()
        except:
            result.testFailed(self.name)
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

class TestSuite(object):
    def __init__(self):
        self.tests = []

    def add(self, test):
        self.tests.append(test)

    def run(self, result):
        i = 0
        for test in self.tests:
            i += 1
            test.run(result)


class TestCaseTest(TestCase):
    def setUp(self):
        self.result = TestResult()

    def testTemplateMethod(self):
        test = WasRun("testMethod")
        test.run(self.result)
        assert ("setUp testMethod tearDown" == test.log)

    def testResult(self):
        test = WasRun("testMethod")
        test.run(self.result)
        assert ("1 run, 0 failed" == self.result.summary())

    def testFailedResult(self):
        test = WasRun("testBrokenMethod")
        test.run(self.result)
        assert ("1 run, 1 failed" == self.result.summary())

    def testFailedResultFormatting(self):
        self.result.testStarted()
        self.result.testFailed("whatever")
        assert ("1 run, 1 failed" == self.result.summary())

    def testSuiteTest(self):
        suite = TestSuite()
        suite.add(WasRun("testMethod"))
        suite.add(WasRun("testBrokenMethod"))
        suite.run(self.result)
        assert ("2 run, 1 failed" == self.result.summary())

    def tearDownCalledIfFail(self):
        test = WasRun("testBrokenMethod")
        test.run(self.result)
        assert (test.log.__contains__("tearDown"))

    def listFailedTests(self):
        test = WasRun("testBrokenMethod")
        test.run(self.result)
        print(self.result.failedTests()[0])
        assert (self.result.failedTests().__sizeof__() == 1)
        assert (self.result.failedTests()[0] == "testBrokenMethod")

    def failedTestWithName(self):
        test = WasRun("testBrokenMethod")
        test.run(self.result)
        assert (self.result.summary().__contains__("testBrokenMethod"))


testSuite = TestSuite()
testSuite.add(TestCaseTest("testTemplateMethod"))
testSuite.add(TestCaseTest("testResult"))
testSuite.add(TestCaseTest("testFailedResultFormatting"))
testSuite.add(TestCaseTest("testFailedResult"))
testSuite.add(TestCaseTest("testSuiteTest"))
testSuite.add(TestCaseTest("tearDownCalledIfFail"))
testSuite.add(TestCaseTest("listFailedTests"))
# testSuite.add(TestCaseTest("failedTestWithName"))
testResult = TestResult()
testSuite.run(testResult)
print(testResult.summary())
