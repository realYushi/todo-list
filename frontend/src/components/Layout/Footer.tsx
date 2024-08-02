export function Footer() {
  return (
    <footer className="bg-gray-500 text-white py-4">
      <div className="container mx-auto px-4 flex flex-wrap justify-between items-center">
        <div className="w-full md:w-1/3 text-center md:text-left">
          <span>&copy; 2024 Yushi Cui. All rights reserved.</span>
        </div>

        <div className="w-full md:w-1/3 text-center md:text-right">
          <a
            href="https://www.linkedin.com/in/yushi-cui-6043aa285/"
            className="mx-2 hover:text-gray-300"
          >
            Linkedin
          </a>
          <a
            href="https://github.com/realYushi"
            className="mx-2 hover:text-gray-300"
          >
            Github
          </a>
          <a
            href="https://blog.yushi91.com"
            className="mx-2 hover:text-gray-300"
          >
            Blog
          </a>
        </div>
      </div>
    </footer>
  )
}
