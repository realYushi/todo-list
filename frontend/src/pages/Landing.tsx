import heroImage1 from "../assets/hero-1.jpg";
import heroImage2 from "../assets/hero-2.jpg";

import { Navbar } from "../components/Landing/Nav";
import { HeroSection } from "../components/Landing/Hero";
import { FormComponent } from "../components/Landing/FormComponent";
import { Footer } from "../components/Layout/Footer";
export function Landing() {
  return (
    <>
      <Navbar />
      <HeroSection
        imageSrc={heroImage1}
        title="Streamline your workflow"
        description="Our todo app helps you stay organized and focused, with features like task prioritization, due dates, and reminders."
        buttonText="Get Started"
        buttonLink="#registerForm"
      />
      <HeroSection
        imageSrc={heroImage2}
        title="Simplify your life with Todo"
        description="Stay organized and on top of your tasks with our intuitive todo list app."
        buttonText="Get Started"
        buttonLink="#registerForm"
      />
      <FormComponent />
      <Footer />
    </>
  );
}
