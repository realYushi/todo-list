import heroImage1 from "@assets/hero-1.jpg"
import heroImage2 from "@assets/hero-2.jpg"

import { Navbar } from "@pages/Landing/LandingNav"
import { HeroSection } from "@pages/Landing/LandingHero"
import { FormComponent } from "@pages/Landing//LandingForm"
import { Footer } from "@components/Layout/Footer"
export function Landing() {
  return (
    <>
      <div className="bg-neutral">
        <Navbar />
        <HeroSection
          imageSrc={heroImage1}
          title="Streamline your workflow"
          description="Our todo app helps you stay organized and focused, with features like task prioritization, due dates, and reminders."
          buttonText="Get Started"
          buttonLink="#loginForm"
        />
        <HeroSection
          imageSrc={heroImage2}
          title="Simplify your life with Todo"
          description="Stay organized and on top of your tasks with our intuitive todo list app."
          buttonText="Get Started"
          buttonLink="#loginForm"
        />
        <FormComponent />
        <Footer />
      </div>
    </>
  )
}
