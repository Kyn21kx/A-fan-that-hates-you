from math import exp

def sigmoid(t):
	return 1/(1 + exp(8*t -4))


for i in range(0, 10, 1):
	this_line = []
	for j in range(0, 10, 1):
		this_line.append(sigmoid((i/10 + j/100)))

	print(this_line)	
