TradingSystem
=============

This a <i>demo project</i> showing a line of business application for trading bonds.
When finished it should be able to trade bonds on the Genium Inet Exchange.
The Model, UI and all other parts of the system should uses termonology from the domain - which is mostly
defined by the Genium Inet Protocols and Market Models.

<B>projects:</B>

<B>Demo Project</B> - trading bonds on Genium Inet

<B>DomainModel</B> contains the model classes  eg instrument.

<B>FakeRepository</B> contains repositories for testing and proff of concept

<B>Repositories</B> contains repositories for CRUD operation of the objects

<B>TraderClientTelerikWPF</B> is the client project which in iteration 1 is able to....:
- shows yield and price depending on which ordertype and instrument is choosen
- - OrderType market shows no price or yield
- - Intrument whichs are traded on yield shows yield - instruments traded on price shows price


Dependencies : Telerik WPF Controls

Runs on Windows 8.

Purpose:
This is a reference projet which should show the following:
- domain driven design approach.
- clean code: 
- - use principle of least surprises: - if a ui-element is not relevant it should not be shown to the user.
- - The same goes for the model and communication layers.
- use of the following technoligies and methods : 
- - Domain Driven Design
- - Depedency Injection,
- - Model Driven Design
- - Continues Delivery
- - Unit Test
- - Automated Integration Test
- - WPF
- - Web development (ASP.NET HTML5 JavaScript)
- - OOAD
