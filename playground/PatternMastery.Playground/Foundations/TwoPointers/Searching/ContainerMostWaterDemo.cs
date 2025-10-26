using PatternMastery.Foundations.TwoPointers.Searching;
namespace PatternMastery.Playground.Foundations.TwoPointers.Searching;

internal sealed class ContainerMostWaterDemo : IDemo
{
    public string Key => "container-most-water";
    public string Title => "Foundations / Two Pointers / Searching / Container Most Water";

    public void Run()
    {
        var h = new[] {1,8,6,2,5,4,8,3,7};
        Program.Header(Title);
        Program.ShowArray("Heights", h);

        var (area, i, j) = ContainerMostWater.Find(h);
        Console.WriteLine(area == 0 ? "No container" :
            $"Max area = {area} using lines ({i},{j}) with heights ({h[i]},{h[j]}) and width {j - i}");
    }
}