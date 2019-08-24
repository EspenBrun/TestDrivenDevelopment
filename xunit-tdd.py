class TestCase:
	def __init__(self, name):
		self.name = name
	def run(self):
		# This code will attr/method with name 'name'
		# Fails if we do not have anything named 'name'
		print("Attempting to find method or attribute named " + self.name)
		method = getattr(self, self.name)
		print("Found it: " + self.name + "()")
		method()

class WasRun(TestCase):
	'''This is the docstring'''
	def __init__(self, name):
		self.wasRun = None
		TestCase.__init__(self, name)
	def testMethod(self):
		print("testMethod() was called, setting wasRun = 1")
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
	def testRunning(self):
		test = WasRun("testMethod")
		assert(not test.wasRun)
		test.run()
		assert(test.wasRun)

TestCaseTest("testRunning").run()
