# Currency to English Word Task 

## Instructions

Below is a description of a function to implement. It's not a trick question but there are a few
logic details to work out. We're interested in:

* How you solve a problem
* Clean readable code
* Good understanding of unit testing

There isn't any time limit but it shouldn't take more than a couple of hours, and if you are
really stuck please get in touch for a hint. We work in a team in the real world so sensible
questions wont be considered a failure!

The easiest way to submit is by writing in .NET or node.js, and sharing a github repository with
us. If you have other tools you'd like to use just ask and we'll work something out.


## Specification

Write a function which returns a dollar value written out in English words.

The function should handle all values from 0 to 1000, up to two decimal places. If there is any
ambiguity in the spec you are welcome to make a decision on an appropriate output and document it.

Include related unit tests to show that it works.

A few examples:

| Input | Output                             |
| ----- | ---------------------------------- |
| 0     | "zero dollars"                     |
| 0.12  | "twelve cents"                     |
| 10.55 | "ten dollars and fifty five cents" |
| 120   | "one hundred and twenty dollars"   |


# Implementation By Umang 

## Some Assumptions
* We want to be strict about business rules i.e., solution implementation doesn't accept more than 2 decimal places & no rounding of a valid input. All business rules are in MoneyToWordsConverter.cs
* We can provide different but valid format as original argument i.e., $1000, 1000, 1,000.00 are all valid string in NZ culture. 
* We should be easily be able to extend solution for million/billion/trillion digits to words conversion. WholeNumberToWords.cs can currently supports 999999. 





