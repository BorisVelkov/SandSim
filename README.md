# SandSim
Particle Simulation 

-exe a relevantni soubory = publish.zip
-zdrojak, program kod = Program.cs , SandSimulator.csproj

jak na to:

1-0 materiály (kamení, antigravitace, voda, dřevěná podpěra, písek, led, oheň, pára, cloner, guma)

A/S togglue velikost štětce

Q, W, E, R určuje rychlost simulace (nejrychlejší až nejpomalejší)

C čistí vše

problémy:

-Neoptimalizováno (oprava - známé důvody jsou: 1000x800 Array když jsou potřeba pouze 100x80 polí, žádné invokované metody (pouze lineární kód), žádné využití objektů, řešením by byl 3 celkový přepis (již jsem to několikrát zkoušel opravit a pokaždé se něco rozbilo))

-Změnění velikosti okna desynchronizuje myš a input (rovněž jsem bezvýsledňe zkoušel opravit

