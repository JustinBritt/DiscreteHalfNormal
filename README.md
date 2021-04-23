This is a partial implementation of the discrete half-normal distribution presented by [Kemp](https://link.springer.com/chapter/10.1007/978-0-8176-4626-4_27).

In `DiscreteHalfNormal.Classes.Calculations.qθMeanCalculation`, the Calculate method accepts ranges of x, q, and θ values, step sizes for q and θ values, and a tolerance for
the means. The method uses these range and step values to calculate means and then returns q, θ, and calculated mean triples that fall within the specified range.
