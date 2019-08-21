class WasRun:
	'''This is the docstring'''
	def __init__(self, name):
		self.wasRun = None
		self.name = name
	def testMethod(self):
		print("The testMethod was called. The constructor argument for name was: " + self.name)
		self.wasRun = 1
	def run(self):
		print("The interface to a method in this class was called. I will fail unless you use one of these:")
		# self.testMethod()
		# print(self.__doc__)
		print(dir(self))
		method = getattr(self, self.name)
		print("got method with name " + self.name)
		method()
	def methodA(self):
		print("method A called")
	def methodB(self):
		print("methodB called")

test = WasRun("methodB")
print(test.wasRun)
# test.testMethod()
# dont want to run the test method directly, use an interface
test.run()
print(test.wasRun)
