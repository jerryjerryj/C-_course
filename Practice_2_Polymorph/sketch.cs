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

+ ManaRegenFeature ManaRegen;
+ SpeedFeature Speed;
+ PowerFeature Power;

+  List<Abilities> abilities {get; private set;}

+ abstract void UseAbility(int abilityId); //������ ���� � ���������� �����������. ����� - exception

+ void ChangeHealth(int amount); // ���� �������� ������ ��� ����� 0 - exception => �������� �������
}

class Warrior{
}

abstract class Ability
{
- int Cost;
- int CooldownSec;
- double Amount;
+ abstract void Use(Character influencedCharacter){}; //������ buff �� ���������, ����������� �������� ������� buff ����������� buffcontroller
}

abstract class OnSelfAbility : Ability{
    Use ???
}

//abstract class ManaRegenAbility : Ability{}
class SimpleManaAcceleration : OnSelfAbility{}
class PermanentManaAcceleration : OnSelfAbility{}// ����� ����, �� ���� ������ ��������
class ManaSlowDown : Ability{}
//�� �������� � power � speed

