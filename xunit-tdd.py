class WasRun:
	def __init__(self, name):
		self.wasRun = None
		self.name = name
	def testMethod(self):
		print("The wasRun object was called. The constructor argument for name was: " + self.name)
		self.wasRun = 1
	def run(self):
		print("The interface to testMethod(), the method run(), was executed")
		self.testMethod()

test = WasRun("someName")
print(test.wasRun)
# test.testMethod()
# dont want to run the test method directly, use an interface
test.run()
print(test.wasRun)
