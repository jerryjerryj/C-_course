abstract class Feature{

+ double FeatureAmount {get; private set;}
+ Feature(int featureAmount);
}

//class HealthFeature : Feature {};  
class ManaRegenFeature : Feature {}; 
class SpeedFeature : Feature {}; 
class PowerFeature : Feature {}; 

class Buff{
- Character character;
- Feature feature;
- Time InspiredTime;

+ void Buff(); // изменяет feature у персонажа
+ void UnBuff(); // изменяет feature у персонажа обратно
+ bool isInspired(Time currentTime);

}

class BuffController{
// запускается извне каждые n секунд или 1 ход (если пошаговая игра)
+ List<Buff> Buffs;
+ void CheckAll(); // откатывает баффы с вышедшем временем, а затем удаляет их из своего списка.

}

abstract class Character
{
// разница между int и feature :
// int - значения больше 0 => нельзя делать откат => нельзя вещать buff т.к. у него есть срок действия
// feature - значения любые

+ int Health {get; private set;}
+ int Mana {get; private set;}

+ ManaRegenFeature ManaRegen;
+ SpeedFeature Speed;
+ PowerFeature Power;

+  List<Abilities> abilities {get; private set;}

+ abstract void UseAbility(int abilityId); //тратит ману и использует способность. иначе - exception

+ void ChangeHealth(int amount); // если здоровье меньше или равно 0 - exception => персонаж умирает
}

class Warrior{
}

abstract class Ability
{
- int Cost;
- int CooldownSec;
- double Amount;
+ abstract void Use(Character influencedCharacter){}; //вешает buff на персонажа, посредством передачи объекта buff контроллеру buffcontroller
}

abstract class OnSelfAbility : Ability{
    Use ???
}

//abstract class ManaRegenAbility : Ability{}
class SimpleManaAcceleration : OnSelfAbility{}
class PermanentManaAcceleration : OnSelfAbility{}// много маны, но бафф быстро проходит
class ManaSlowDown : Ability{}
//по аналогии с power и speed

