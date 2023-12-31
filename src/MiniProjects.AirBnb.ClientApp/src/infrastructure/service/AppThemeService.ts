/*
    Provides app theme functionality.
 */
export class AppThemeService {
    /**
     * Checks if the dark mode is enabled.
     *
     * @returns {boolean} True if dark mode is enabled, false otherwise.
     */
    public isDarkMode(): boolean {
        if (this.getValue() !== null)
            return this.getValue();

        return window.matchMedia("(prefers-color-scheme: dark)").matches;
    }

    /**
     * Toggles the dark mode of the application.
     * It adds or removes the "dark" class from the document body and updates the darkMode value in localStorage.
     */
    public toggleDarkMode(): void {
        this.toggleDarkMode();

        const darkMode = this.isDarkMode();
        this.setValue(!darkMode);
        // localStorage.setItem("darkMode", (!darkMode).toString());
    }

    /**
     * Sets the application theme based on the user's preference.
     */
    public setAppTheme(): void {
        if (this.isDarkMode()) {
            this.addValue();
        } else {
            this.removeValue();
        }

        this.setValue(this.isDarkMode());
    }

    private getValue(): boolean {
        return localStorage.getItem("darkMode") !== null ? localStorage.getItem("darkMode") === "true" : false;
    }

    private setValue(darkMode: boolean) {
        localStorage.setItem("darkMode", darkMode.toString());
    }

    private addValue() {
        document.body.classList.add("dark");
    }

    private removeValue() {
        document.body.classList.remove("dark");
    }

    private toggleValue() {
        document.body.classList.toggle("dark");
    }
}