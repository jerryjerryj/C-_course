
Пошаговая игра.

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

+ ManaRegenFeature ManaRegen {get; private set;}
+ SpeedFeature Speed {get; private set;}
+ PowerFeature Power {get; private set;}

+ abstract void UseAbility(); //тратит ману и использует способность. иначе - exception

+ void ChangeFeature(Feature f);
+ void ChangeHealth(int amount); // если здоровье меньше или равно 0 - exception => персонаж умирает
}

class Warrior : Character
{
   IncreasePower increasePower;
   DecreasePower decreasePower;
   SlowManaRegen slowManaRegen;
}
class Healer : Character
{
   FasterManaRegen fasterManaRegen;
   IncreaseSpeed increaseSpeed;
}
class Mage : Character
{
   DecreaseSpeed decreaseSpeed;
   DecreasePower decreasePower;
   FasterManaRegen fasterManaRegen;
   
}

abstract class Ability
{
- static int Cost;
- static int CooldownSec;
- static double Amount;
protected void UseAbility(Character influencedCharacter){}; //вешает buff на персонажа, посредством передачи объекта buff контроллеру buffcontroller
}

abstract class OnSelfAbility : Ability
{

- Character myself;
+ OnSelfAbility(Character myself){}

+ virtual void Use();

}

abstract class OnSomeoneAbility : Ability
{
+ virtual void Use(Character character);
}

class FasterManaRegen : OnSelfAbility 
{
+ FasterManaRegen(Character myself): base(myself){}
}

class SlowManaRegen : OnSomeoneAbility {}

class IncreasePower : OnSelfAbility 
{
+ IncreasePower(Character myself): base(myself){}
}

class DecreasePower : OnSomeoneAbility {}

class IncreaseSpeed : OnSelfAbility 
{
+ IncreaseSpeed(Character myself): base(myself){}
}
class DecreaseSpeed : OnSomeoneAbility {}


/*
abstract class ManaRegenAbility : Ability
{
+ virtual void Use(Character influencedCharacter){};
}
class SimpleManaAcceleration : ManaRegenAbility
{
+ override void Use(Character influencedCharacter){};
}

class PermanentManaAcceleration : ManaRegenAbility// много маны, но бафф быстро проходит
{
+ override void Use(Character influencedCharacter){};
}

class ManaSlowDown : ManaRegenAbility
{
+ override void Use(Character influencedCharacter){};
}
// speed и power по аналогии...
*/
