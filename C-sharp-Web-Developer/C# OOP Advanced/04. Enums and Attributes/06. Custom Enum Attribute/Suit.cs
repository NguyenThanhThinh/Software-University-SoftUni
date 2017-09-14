using _06.Custom_Enum_Attribute;

namespace _01.Card_Suit
{
    [Type(Type = "Enumeration", Category = "Suit", Description = "Provides suit constants for a Card class.")]
    public enum Suit
    {
        Clubs,
        Diamonds = 13,
        Hearts = 26,
        Spades = 39
    } 
}