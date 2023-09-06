using System;
using Models;

new PhoneCall()
    
    // We set listeners that print what is said but with a twist:
    // Changes the text to lower case for caller and to upper case for contact.
    
    .ListenOnCaller(s => Console.WriteLine($"Gand: {s.ToLower()}"))
    .ListenOnContact(s => Console.WriteLine($"  Greml: {s.ToUpper()}"))
    
    // Conversation over this phone call starts.
    
    .Speak("Good evening!")
    .Respond("Hello. You have reached the Gremlings. Who's calling?")
    
    // On demand apply a different delegate for this.
    // Now with no text alterations (aside from the names and indentation).
    
    .ListenOnCaller(s => Console.WriteLine($"Gand: {s}"))
    .ListenOnContact(s => Console.WriteLine($"  Greml: {s}"))
    
    // More conversation.
    
    .Speak("Oh. Right. This is your friend Gandalf the old.")
    .Speak("Hope I'm not disturbing.")
    .Respond("Not at all!")
    .Respond("We were just about to finish up here with the lame News of the Rings.")
    .Speak("Ah!")
    .Respond("Yeah it is not very much happening around these parts.")
    .Respond("Might as well keep the radio on silent and score some points with the dwarves instead haha.")
    .Speak("That for sure is a good point.")
    .Speak("Well you seem to be having a lack of fun today.")
    .Speak("Meet up at 9 for some magic tharwth on the courtyard?")
    .Respond("Oh yes. It is time for that. Love to sport with ya.")
    .Speak("Love it! See you there.")
    .Respond("Okay. Bye.")
    .Speak("Bye.")
    
    // Hanging up without unregistering listeners delegates leaves
    // a beeep- beeep on the other end.
    // 
    // If you really dislike this, then idk what to tell you.
    // Might as well just leave calls hanging, that works as well.
    
    .HangUp(fromCallingSide: true);
