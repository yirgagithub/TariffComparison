# TariffComparison

**Project Structure and Desgin**

![image](https://user-images.githubusercontent.com/17432146/212719950-af943e9e-4507-43e4-87f4-40a7e6569e6e.png)


As shown in the UML diagram I have have Tariff abstract class with BasicTariff and PackageTariff as subclasses. I made the Tariff class an abstract rather than an interface becuase I want to add implementation to ToString method for logging purpose and rather than adding it in all subsclasses it is much better to be inside the parent class.

And also I have separate attributes in both subclass I didn't add them in parent class because if we were to add another tariff as subclass and they don't have these as an attribute it will violate Interface Segrgation principle of SOLID principle.


**Using factory method design principle**

On this scenario we only have two tariff products but in the future we might want to add another tariff products and also rather than creating each instance of tariff directly using new keywork it will make our application tightly coulpled if we use factory to create instances.

![image](https://user-images.githubusercontent.com/17432146/212721921-fe87cade-9d18-46a2-9823-097b83dd6736.png)

As show in the image we are creating new instances using a factory method. 

**Over all request flow**

![image](https://user-images.githubusercontent.com/17432146/212724776-8a83d7c9-9359-4c6b-979e-2343a2613b5f.png)

● In Controller: Class the TariffComparisonService
● In TariffComparisonService: It validates the consumption using fluent validation. If succes it wil call TariffComparison class if not it will throw an Exception(It will be handled by ErrorHandlingMiddleware).
● In TariffComparison: it will use TariffType to create instance using TariffFactory class. After that it will sort the list by the AnnualCost and return ordered list. If invalid TariffType passed it will throw an Exceptoin
