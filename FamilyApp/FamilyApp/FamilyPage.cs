using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace FamilyApp
{
    public class FamilyPage : ContentPage
    {
        public FamilyPage()
        {
            var familyMembers = new[]
                {
                    new { name = "Mary", color=Color.Teal, text = "This is me! I'm an application developer and technical instructor." },
                    new { name = "Martin", color=Color.Red, text = "My most awesome husband! He does accounting." },
                    new { name = "Skadi", color=Color.Green, text = "Our big pup. She's about 100lbs, and that's not fat. She might be part St. Bernard, but has fur more like a Golden." },
                    new { name = "Bart", color=Color.Gray, text = "The old man cat. He's been with me since I first moved out on my own and is almost 21 years old!" },
                    new { name = "Abby", color=Color.Pink, text = "Our little girl cat. She's an excellent mouser. One of the 3 backyard born strays we've taken in." },
                    new { name = "Kyo", color=Color.Yellow, text = "The particular orange tabby of the family.  While his fellow litter mates ran off, he just looked at me as I scooped him into a flower pot and brought him home." },
                    new { name = "Fred", color=Color.Blue, text = "One of the last kittens from our neighborhood momma cat.  He's a big cat, but has the softest sandy colored fur." }
                };

            StackLayout familyStack = new StackLayout();

            // This builds a Label to add to the StackLayout with formatted text for each person in the array above
            foreach (var member in familyMembers)
            {
                familyStack.Children.Add(
                    new Label
                    {
                        FormattedText = new FormattedString
                        {
                            Spans =
                            {
                                new Span
                                {
                                    FontAttributes = FontAttributes.Bold,
                                    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                                    Text = member.name + Environment.NewLine
                                },
                                new Span
                                {
                                    Text = member.text,
                                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
                                }
                            }
                        },
                        BackgroundColor = member.color
                    });
            }

            // Note that this should expand to fill the bottom space if there is no scrolling.
            familyStack.Children.Add(
                new Label
                {
                    Text = "That's the Mosman family!",
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                    VerticalOptions = LayoutOptions.EndAndExpand
                });

            // Add a title to the Page
            Title = "My Family App";

            // Adds padding so we don't hide under the status bar
            Padding = new Thickness(5, Device.OnPlatform(20, 5, 5), 5, 5);
            Content = new ScrollView
            {
                Content = familyStack
            };
        }
    }
}
