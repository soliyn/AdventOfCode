using CSharp.Day04;

namespace CSharp.Tests.Day04.GridOfPaperTests;

public class GetNumberOfRemovableRolls
{
    [Fact]
    public void Should_Return_CorrectNumberOfRemovableRolls()
    {
        char[][] grid = new char[][]
        {
            [ '.', '.', '@', '@', '.', '@', '@', '@', '@', '.' ],
            [ '@', '@', '@', '.', '@', '.', '@', '.', '@', '@' ],
            [ '@', '@', '@', '@', '@', '.', '@', '.', '@', '@' ],
            [ '@', '.', '@', '@', '@', '@', '.', '.', '@', '.' ],
            [ '@', '@', '.', '@', '@', '@', '@', '.', '@', '@' ],
            [ '.', '@', '@', '@', '@', '@', '@', '@', '.', '@' ],
            [ '.', '@', '.', '@', '.', '@', '.', '@', '@', '@' ],
            [ '@', '.', '@', '@', '@', '.', '@', '@', '@', '@' ],
            [ '.', '@', '@', '@', '@', '@', '@', '@', '@', '.' ],
            [ '@', '.', '@', '.', '@', '@', '@', '.', '@', '.' ]
        };
        
        Assert.Equal(43, GridOfPaper.GetNumberOfRemovableRolls(grid));
    }
}