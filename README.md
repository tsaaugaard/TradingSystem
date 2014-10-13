TradingSystem
=============

This a <i>demo project</i> showing a line of business application for trading bonds.
When finished it should be able to trade bonds on the Genium Inet Exchange.
The Model, UI and all other parts of the system should use termonology from the domain - which is mostly
defined by the Genium Inet Protocols and Market Models.
There should be few surprises - if a ui-element is not relevant it should not be shown to the user.
The same goes for the model and communication layers.

<B>projects:</B>

<B>Demo Project</B> - trading bonds on Genium Inet

<B>DomainModel</B> contains the model classes  eg instrument.

<B>FakeRepository</B> contains repositories for testing and proff of concept

<B>Repositories</B> contains repositories for CRUD operation of the objects

TraderClientTelerikWPF is the client project in iteration 1:
shows yield and price depending on which ordertype and instrument is choosen
- OrderType market shows no price or yield
- Intrument whichs are traded on yield shows yield - instruments traded on price shows price


Dependencies : Telerik WPF Controls

Runs on Windows 8.
