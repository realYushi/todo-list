export function Footer() {
    return (
        <footer className="bg-gray-500 text-white py-4">
            <div className="container mx-auto px-4 flex flex-wrap justify-between items-center">
                <div className="w-full md:w-1/3 text-center md:text-left">
                    <span>
                        &copy; 2023 Your Company Name. All rights reserved.
                    </span>
                </div>

                <div className="w-full md:w-1/3 text-center md:text-right">
                    <a href="#" className="mx-2 hover:text-gray-300">
                        Facebook
                    </a>
                    <a href="#" className="mx-2 hover:text-gray-300">
                        Twitter
                    </a>
                    <a href="#" className="mx-2 hover:text-gray-300">
                        Instagram
                    </a>
                </div>
            </div>
        </footer>
    );
}
