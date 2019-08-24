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

class WasRun(TestCase):
	'''This is the docstring'''
	def __init__(self, name):
		TestCase.__init__(self, name)
	def setUp(self):
		self.wasRun = None
		self.wasSetUp = 1
	def testMethod(self):
		self.wasRun = 1

# TestCaseTest inherits TestCase, so it will have run()
# Run is the method that dynamically invokes a method
	# with the same name as is given in the `name` parameter in the constructor
# So the method with name "testRunning" is called
# testRunning() is a method that does what we manuallt tested earlier:
	# creates a WasRun, which also inherits TestCase and the run() method,
	# executes run, which dynimcally invokes the method with same name as given in `name` param in constructor
	# which is testMethod(), which sets the flag to 1.
# So: We now have an actual test of what we earlier visually verified

class TestCaseTest(TestCase):
	def setUp(self):
		self.test = WasRun("testMethod")
	def testRunning(self):
		self.test.run()
		assert(self.test.wasRun)
	def testSetUp(self):
		self.test.run()
		assert(self.test.wasSetUp)

TestCaseTest("testRunning").run()
TestCaseTest("testSetUp").run()
