interface HeroSectionProps {
  imageSrc: string;
  title: string;
  description: string;
  buttonText: string;
  buttonLink: string;
}

export function HeroSection({
  imageSrc,
  title,
  description,
  buttonText,
  buttonLink,
}: HeroSectionProps) {
  return (
    <div className="hero col-auto min-h-screen bg-neutral">
      <div className="hero-content flex-col lg:max-w-2xl lg:flex-row-reverse">
        <img src={imageSrc} className="rounded-lg shadow-2xl" />
        <div>
          <h1 className="text-5xl font-bold">{title}</h1>
          <p className="py-6">{description}</p>
          <button className="btn btn-primary">
            <a href={buttonLink}>{buttonText}</a>
          </button>
        </div>
      </div>
    </div>
  );
}
