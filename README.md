# TariffComparison

**Project Structure and Desgin**

![image](https://user-images.githubusercontent.com/17432146/212719950-af943e9e-4507-43e4-87f4-40a7e6569e6e.png)



**Model design reasoning** 

All tariffs will have a name, consumption, and annual cost. But not all tariffs have consumption cost per kwh or base cost as an example a flat tariff doesn't have consumption cost per kwh. Other tariffs may have a different calculation model, such as a time-of-use tariff, where the cost changes depending on the time of day or the day of the week when the energy is consumed. 

So it  make so much sense to put these attributes(CONSUMPTION_COST, BASE_COST) in subclass than parent. Even if I put them in parent class now and wanted to add new tariffs in the future we have to update our parent class Tariff or it will violate the I(Interface Segregation principle) in the SOLID design principles.


The UML diagram illustrates the use of an abstract Tariff class, with BasicTariff and PackageTariff as subclasses. The Tariff class was implemented as an abstract class in order to add an implementation for the ToString method for logging purposes. We can have an interface and add ToString in each subclass but it will be repetitive. 

**Using factory method design principle**


The factory method design principle is also utilized in this scenario. While currently only two tariff products are present, the implementation allows for the possibility of adding additional tariff products in the future. Additionally, using a factory method to create instances of tariffs rather than directly using the "new" keyword helps to mitigate the risk of tight coupling within the application.


![image](https://user-images.githubusercontent.com/17432146/212721921-fe87cade-9d18-46a2-9823-097b83dd6736.png)

As show in the image we are creating new instances using a factory method. 

**Over all request flow**

![image](https://user-images.githubusercontent.com/17432146/212724776-8a83d7c9-9359-4c6b-979e-2343a2613b5f.png)

● In Controller: Call the TariffComparisonService.

● In TariffComparisonService: It validates the consumption using fluent validation. If success it wil call TariffComparison class if not it will throw an Exception(It will be handled by ErrorHandlingMiddleware).

● In TariffComparison: it will use TariffType to create instance using TariffFactory class. After that it will sort the list by the AnnualCost and return ordered list. If invalid TariffType passed it will throw an Exceptoin

**You can use Swagger to test**

![image](https://user-images.githubusercontent.com/17432146/212743391-cb41b5cd-42c6-41ab-ba3f-15e8c92134fe.png)


**Requirement this repo uses dotnet core 5**
