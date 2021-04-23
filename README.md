# Introduction
This is a partial implementation of the discrete half-normal distribution presented by [Kemp](https://link.springer.com/chapter/10.1007/978-0-8176-4626-4_27).

# Methods
In `DiscreteHalfNormal.Classes.Calculations.qθMeanCalculation`, the Calculate method accepts ranges of x, q, and θ values, step sizes for q and θ values, and a tolerance for
the means. The method uses these range and step values to calculate means and then returns q, θ, and calculated mean triples that fall within the specified range.

# Application
The current application of this is to generate patient length of stay distributions. For this application, xUpperBound and targetMean correspond to the maximum allowed and mean, respectively, lengths of stay.
The q, θ, and calculated mean triples can then be sampled from in order  to generate different scenarios, where each scenario has approximately the same mean.

# Future Work
This could be extended to also generate q, θ, and calculated variance triples. This would allow for the generation of scenarios with different means but approximately the same variance.