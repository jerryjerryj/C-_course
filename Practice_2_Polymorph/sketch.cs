
��������� ����.

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

+ void Buff(); // �������� feature � ���������
+ void UnBuff(); // �������� feature � ��������� �������
+ bool isInspired(Time currentTime);

}

class BuffController{
// ����������� ����� ������ n ������ ��� 1 ��� (���� ��������� ����)
+ List<Buff> Buffs;
+ void CheckAll(); // ���������� ����� � �������� ��������, � ����� ������� �� �� ������ ������.

}

abstract class Character
{
// ������� ����� int � feature :
// int - �������� ������ 0 => ������ ������ ����� => ������ ������ buff �.�. � ���� ���� ���� ��������
// feature - �������� �����

+ int Health {get; private set;}
+ int Mana {get; private set;}

+ ManaRegenFeature ManaRegen {get; private set;}
+ SpeedFeature Speed {get; private set;}
+ PowerFeature Power {get; private set;}

+ abstract void UseAbility(); //������ ���� � ���������� �����������. ����� - exception

+ void ChangeFeature(Feature f);
+ void ChangeHealth(int amount); // ���� �������� ������ ��� ����� 0 - exception => �������� �������
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
protected void UseAbility(Character influencedCharacter){}; //������ buff �� ���������, ����������� �������� ������� buff ����������� buffcontroller
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

class PermanentManaAcceleration : ManaRegenAbility// ����� ����, �� ���� ������ ��������
{
+ override void Use(Character influencedCharacter){};
}

class ManaSlowDown : ManaRegenAbility
{
+ override void Use(Character influencedCharacter){};
}
// speed � power �� ��������...
*/
