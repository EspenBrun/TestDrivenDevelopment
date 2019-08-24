class WasRun:
	'''This is the docstring'''
	def __init__(self, name):
		self.wasRun = None
		self.name = name
	def testMethod(self):
		print("testMethod() was called, setting wasRun = 1")
		self.wasRun = 1
	def run(self):
		# This code will attr/method with name 'name'
		# Fails if we do not have anything named 'name'
		print("Attempting to find method or attribute named " + self.name)
		method = getattr(self, self.name)
		print("Found it: " + self.name + "()")
		method()

test = WasRun("testMethod")
print("### Test start")
print("")
print("Checking that test is not run yet. test.wasRun should be None:")
print("test.wasRun is: ")
print(test.wasRun)
print("")
print("Will now run the testMethod through the run() proxy")
# dont want to run the test method directly, use an proxy
test.run()

print("Checking that test has run. test.wasRun should be 1:")
print("test.wasRun is:")
print(test.wasRun)
