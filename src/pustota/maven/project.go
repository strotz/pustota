package maven

type Project struct {
	ArtifactId string
	GroupId    string
	Version    string
	Comment    string      `xml:",comment"`
}
