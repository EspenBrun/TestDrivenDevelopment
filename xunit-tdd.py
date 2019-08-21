class WasRun:
	def __init__(self, name):
		self.wasRun = None
		self.name = name
	def testMethod(self):
		print("The wasRun object was called. The constructor argument for name was: " + self.name)
		self.wasRun = 1

test = WasRun("someName")
print(test.wasRun)
test.testMethod()
print(test.wasRun)
