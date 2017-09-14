public class AnimalClinic
{
    private static int patientId;
    private static int healedAnimalsCount;
    private static int rehabilitedAnimalsCount;


    static AnimalClinic()
    {
        healedAnimalsCount = 0;
        rehabilitedAnimalsCount = 0;
        patientId = 1;
    }

    public static int PatientId
    {
        get { return patientId; }
        set { patientId = value; }
    }

    public static int HealedAnimalsCount
    {
        get { return healedAnimalsCount; }
        set { healedAnimalsCount = value; }
    }

    public static int RehabilitedAnimalsCount
    {
        get { return rehabilitedAnimalsCount; }
        set { rehabilitedAnimalsCount = value; }
    }

    public static void KeepTrackOfHealedAnimals()
    {
        healedAnimalsCount++;
        patientId++;
    }

    public static void KeepTrackOfRehabilitedAnimals()
    {
        rehabilitedAnimalsCount++;
        patientId++;
    }
}